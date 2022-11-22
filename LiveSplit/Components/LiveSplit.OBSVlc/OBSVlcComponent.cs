using LiveSplit.Model;
using LiveSplit.UI.Components;
using LiveSplit.Options;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;
using OBSWebsocketDotNet.Types.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LiveSplit.OBSVlc
{
    public class OBSVlcComponent : LogicComponent, IDeactivatableComponent
    {
        public OBSVlcSettings Settings { get; set; }
        public LiveSplitState State { get; set; }
        public System.Timers.Timer SynchronizeTimer { get; set; }

        private class OBSVLCErrorException : Exception { public OBSVLCErrorException(string msg = null) : base(msg) { } }

        private string OldOBSUrl { get; set; }

        public override string ComponentName => "OBS VLC Source";

        public bool Activated { get; set; }

        private bool Initialized { get; set; }


        private OBSWebsocket obs;


        public OBSVlcComponent(LiveSplitState state)
        {
            Activated = true;
            Initialized = false;

            obs = new OBSWebsocket();
            obs.Connected += Obs_Connected;

            Settings = new OBSVlcSettings();
            State = state;

            state.OnReset += state_OnReset;
            state.OnStart += state_OnStart;
            state.OnPause += state_OnPause;
            state.OnResume += state_OnResume;
        }

        void state_OnResume(object sender, EventArgs e)
        {
            if (!EnsureConnected())
                return;

            try
            {
                lock (obs)
                    obs.TriggerMediaInputAction(Settings.SourceName, "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_PLAY");

                Synchronize();
            }
            catch (Exception exc)
            {
                Log.Error(exc.ToString());
            }
        }

        void state_OnPause(object sender, EventArgs e)
        {
            if (!EnsureConnected())
                return;

            try
            {
                lock (obs)
                    obs.TriggerMediaInputAction(Settings.SourceName, "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_PAUSE");
            }
            catch (Exception exc)
            {
                Log.Error(exc.ToString());
            }
}

        void state_OnStart(object sender, EventArgs e)
        {
            if (!EnsureConnected())
                return;

            try
            {
                SetPlaylist();

                lock (obs)
                    obs.TriggerMediaInputAction(Settings.SourceName, "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_RESTART");

                Task.Delay(250).ContinueWith(t => Synchronize());
            }
            catch (Exception exc)
            {
                Log.Error(exc.ToString());
            }
        }

        void state_OnReset(object sender, TimerPhase e)
        {
            if (!EnsureConnected())
                return;

            try
            {
                lock (obs)
                    obs.TriggerMediaInputAction(Settings.SourceName, "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_STOP");
            }
            catch (Exception exc)
            {
                Log.Error(exc.ToString());
            }
        }

        private TimeSpan GetCurrentTime()
        {
            return State.CurrentTime[TimingMethod.RealTime].Value;
        }

        public void Synchronize(TimeSpan offset = default)
        {
            if (SynchronizeTimer != null && SynchronizeTimer.Enabled)
                SynchronizeTimer.Enabled = false;
            lock (obs)
                obs.SetMediaInputCursor(Settings.SourceName, Convert.ToInt32((GetCurrentTime() + offset + Settings.Offset).TotalMilliseconds));
            SynchronizeTimer = new System.Timers.Timer(1000);

            SynchronizeTimer.Elapsed += (s, ev) =>
            {
                lock (obs)
                {
                    var status = obs.GetMediaInputStatus(Settings.SourceName);

                    if (status.State == "OBS_MEDIA_STATE_PLAYING")
                    {
                        var currentTime = GetCurrentTime();
                        var delta = status.Cursor - (currentTime + offset + Settings.Offset).TotalMilliseconds;
                        if (Math.Abs(delta) > 500)
                            obs.SetMediaInputCursor(Settings.SourceName, Convert.ToInt32((currentTime + offset + Settings.Offset).TotalMilliseconds + Math.Max(0, -delta)));
                        else
                            SynchronizeTimer.Enabled = false;
                    }
                    else if (status.State == "OBS_MEDIA_STATE_STOPPED" || status.State == "OBS_MEDIA_STATE_ENDED" || status.State == "OBS_MEDIA_STATE_ERROR")
                    {
                        SynchronizeTimer.Enabled = false;
                    }
                }
            };

            SynchronizeTimer.Enabled = true;
        }

        private void SetPlaylist()
        {
            JArray items = new JArray();
            if (!string.IsNullOrWhiteSpace(Settings.MRL))
            {
                items.Add(new JObject
                    {
                        { "value", Settings.MRL },
                        { "hidden", false },
                        { "selected", false }
                    });
            }

            lock (obs)
            {
                obs.SetInputSettings(Settings.SourceName, new JObject { { "playlist", items } }, true);
                obs.TriggerMediaInputAction(Settings.SourceName, "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_STOP");
            }
        }

        AutoResetEvent obsConnectEvt = null;
        private void Obs_Connected(object sender, EventArgs e)
        {
            if (obsConnectEvt != null)
            {
                obsConnectEvt.Set();
            }
        }

        private bool EnsureConnected(bool doThrow = false)
        {
            lock (obs)
            {
                if (Settings.OBSUrl != OldOBSUrl)
                    obs.Disconnect();

                try
                {
                    if (!obs.IsConnected)
                    {
                        obsConnectEvt = new AutoResetEvent(false);
                        using (obsConnectEvt)
                        {
                            obs.ConnectAsync(Settings.OBSUrl, Settings.OBSPassword);
                            obsConnectEvt.WaitOne(1000);
                        }

                        if (!obs.IsConnected)
                            throw new Exception("Failed to connect to OBS");

                        OldOBSUrl = Settings.OBSUrl;
                    }
                }
                catch (Exception e)
                {
                    if (doThrow)
                        throw new OBSVLCErrorException(e.Message);
                    else
                        Log.Error(e.Message);
                    return false;
                }
                finally
                {
                    obsConnectEvt = null;
                }

                return true;
            }
        }

        public override void Update(UI.IInvalidator invalidator, LiveSplitState state, float width, float height, UI.LayoutMode mode)
        {
            if (!Initialized)
            {
                EnsureConnected(false);
                Initialized = true;
            }
        }

        public override void Dispose()
        {
            State.OnReset -= state_OnReset;
            State.OnStart -= state_OnStart;
            State.OnPause -= state_OnPause;
            State.OnResume -= state_OnResume;
            if (SynchronizeTimer != null)
                SynchronizeTimer.Dispose();
            if (obs != null)
                obs.Disconnect();
        }

        public override Control GetSettingsControl(UI.LayoutMode mode)
        {
            return Settings;
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public override void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public int GetSettingsHashCode() => Settings.GetSettingsHashCode();
    }
}
