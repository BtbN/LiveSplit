using LiveSplit.Model;
using LiveSplit.Options;
using LiveSplit.TimeFormatters;
using LiveSplit.UI;
using System;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;

namespace LiveSplit.OBSVlc
{
    public partial class OBSVlcSettings : UserControl
    {
        public string MRL => HttpUtility.UrlPathEncode("file:///" + VideoPath.Replace('\\', '/').Replace("%", "%25"));
        public string VideoPath { get; set; }
        public TimeSpan Offset { get; set; }
        public string SourceName { get; set; }
        public string OBSUrl { get; set; }
        public string OBSPassword { get; set; }

        protected ITimeFormatter TimeFormatter { get; set; }

        public string OffsetString
        {
            get
            {
                return TimeFormatter.Format(Offset);
            }
            set
            {
                if (Regex.IsMatch(value, "[^0-9:.,-]"))
                    return;

                try { Offset = TimeSpanParser.Parse(value); }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
        }

        public OBSVlcSettings()
        {
            InitializeComponent();

            TimeFormatter = new ShortTimeFormatter();

            VideoPath = "";
            Offset = TimeSpan.Zero;
            SourceName = "PB Video";
            OBSUrl = "ws://127.0.0.1:4455";
            OBSPassword = "";

            txtVideoPath.DataBindings.Add("Text", this, "VideoPath", false, DataSourceUpdateMode.OnPropertyChanged);
            txtOffset.DataBindings.Add("Text", this, "OffsetString");
            txtSourceName.DataBindings.Add("Text", this, "SourceName");
            txtObsUrl.DataBindings.Add("Text", this, "OBSUrl");
            txtObsPassword.DataBindings.Add("Text", this, "OBSPassword");
        }

        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;
            VideoPath = SettingsHelper.ParseString(element["VideoPath"]);
            OffsetString = SettingsHelper.ParseString(element["Offset"]);
            SourceName = SettingsHelper.ParseString(element["SourceName"]);
            OBSUrl = SettingsHelper.ParseString(element["OBSUrl"]);
            OBSPassword = SettingsHelper.ParseString(element["OBSPassword"]);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0") ^
                SettingsHelper.CreateSetting(document, parent, "VideoPath", VideoPath) ^
                SettingsHelper.CreateSetting(document, parent, "Offset", OffsetString) ^
                SettingsHelper.CreateSetting(document, parent, "SourceName", SourceName) ^
                SettingsHelper.CreateSetting(document, parent, "OBSUrl", OBSUrl) ^
                SettingsHelper.CreateSetting(document, parent, "OBSPassword", OBSPassword);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Video Files|*.avi;*.mpeg;*.mpg;*.mp4;*.mov;*.wmv;*.m4v;*.flv;*.mkv;*.ogg|All Files (*.*)|*.*"
            };
            if (File.Exists(VideoPath))
            {
                dialog.InitialDirectory = Path.GetDirectoryName(VideoPath);
                dialog.FileName = Path.GetFileName(VideoPath);
            }
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                VideoPath = txtVideoPath.Text = dialog.FileName;
        }
    }
}
