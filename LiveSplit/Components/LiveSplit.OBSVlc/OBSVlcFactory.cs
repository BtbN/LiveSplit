using LiveSplit.Model;
using LiveSplit.OBSVlc;
using System;

namespace LiveSplit.UI.Components
{
    public class OBSVlcFactory : IComponentFactory
    {
        public string ComponentName => "OBS VLC Source";

        public string Description => "Remote controls a VLC source in OBS to sync up a PB video.";

        public ComponentCategory Category => ComponentCategory.Media;

        public IComponent Create(LiveSplitState state) => new OBSVlcComponent(state);

        public string UpdateName => ComponentName;

        public string XMLURL => "";

        public string UpdateURL => "";

        public Version Version => Version.Parse("0.0.1");
    }
}
