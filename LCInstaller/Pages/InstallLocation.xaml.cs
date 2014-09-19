using LCInstaller.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LCInstaller.Pages
{
    /// <summary>
    /// Interaction logic for InstallLocation.xaml
    /// </summary>
    public partial class InstallLocation : Page
    {
        public InstallLocation()
        {
            InitializeComponent();
            Load();
            Install.IsEnabled = false;
        }

        private void Load()
        {
            var Webclient = new WebClient();
            try
            {
                string version = Webclient.DownloadString("http://eddy5641.github.io/LegendaryClient/Releases.Json");

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                LCVersionList Versions = serializer.Deserialize<LCVersionList>(version);
                int I = 0;
                foreach (LCVersions Var in Versions.LCVersions)
                {
                    VersionSelect Version = new VersionSelect();
                    Version.DLTag.Text = Var.DownloadLink;
                    Version.LCVersion.Text = "LegenadryClient V" + Var.VersionId;
                    if (Var.IsBeta)
                        Version.ExtraStuff.Text = "Beta";
                    else if (Var.IsPrerelease)
                        Version.ExtraStuff.Text = "Pre-Release";
                    else
                        Version.ExtraStuff.Text = "Release";
                    VersionSelectInstall.Items.Add(Version);
                    I++;
                }
                XVersino.Content = "There are " + I + " versions that can be downloaded";
            }
            catch
            {
                Logic.Logic.SwichPage<Failed>();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result.ToString() == "OK")
            {
                Location.Text = dialog.SelectedPath;
                Logic.Logic.InstallDirectory = Location.Text;
            }
        }

        private void Install_Click(object sender, RoutedEventArgs e)
        {
            Logic.Logic.SwichPage<DownloadFiles>();
        }

        private void VersionSelectInstall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VersionSelect Version = new VersionSelect();
            Version = sender as VersionSelect;
            Install.IsEnabled = true;
            Logic.Logic.DlLink = Version.DLTag.Text;
        }
    }
}
