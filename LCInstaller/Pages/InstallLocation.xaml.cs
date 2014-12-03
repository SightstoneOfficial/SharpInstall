#region

using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using LCInstaller.Logic;
using MessageBox = System.Windows.MessageBox;

#endregion

namespace LCInstaller.Pages
{
    /// <summary>
    ///     Interaction logic for InstallLocation.xaml
    /// </summary>
    public partial class InstallLocation
    {
        public InstallLocation()
        {
            InitializeComponent();
            Load();
            Install.IsEnabled = false;
            Logic.Logic.InstallDirectory = @"C:\LegenadryClient\";
        }

        private void Load()
        {
            var webclient = new WebClient();
            try
            {
                string version = webclient.DownloadString("http://eddy5641.github.io/LegendaryClient/Releases.Json");

                var serializer = new JavaScriptSerializer();
                var versions = serializer.Deserialize<LCVersionList>(version);
                int I = 0;
                foreach (LCVersions var in versions.LCVersions)
                {
                    var Version = new VersionSelect
                    {
                        DLTag = {Text = var.DownloadLink},
                        VersionTag = {Text = var.VersionId},
                        LCVersion = {Text = "LegenadryClient V" + var.VersionId}
                    };

                    if (var.IsBeta)
                        Version.ExtraStuff.Text = "Beta";
                    else if (var.IsPrerelease)
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

            if (result.ToString() != "OK")
                return;

            Location.Text = dialog.SelectedPath + "LegendaryClient";
            Logic.Logic.InstallDirectory = Location.Text;
        }

        private void Install_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Directory.Exists(Logic.Logic.InstallDirectory))
                    Directory.CreateDirectory(Logic.Logic.InstallDirectory);
                else
                {
                    if (
                        MessageBox.Show(
                            "The directory that you are trying to install LegenadryClient into already exists. Delete?",
                            "Install  Error", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) ==
                        MessageBoxResult.Yes)
                    {
                        Directory.Delete(Logic.Logic.InstallDirectory, true);
                    }
                    else
                    {
                        MessageBox.Show(
                            "The installer will now exit because the installation directory already exists",
                            "Install Exit", MessageBoxButton.OK, MessageBoxImage.Information);
                        Environment.Exit(0);
                    }
                }
            }
            catch
            {
                DownloadLogic.DownloadAdmin();
            }
            Logic.Logic.SwichPage<DownloadFiles>();
        }

        private void VersionSelectInstall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var version = VersionSelectInstall.SelectedItem as VersionSelect;

            Install.IsEnabled = true;

            if (version == null)
                return;

            Logic.Logic.DlLink = version.DLTag.Text;
            Logic.Logic.Version = version.VersionTag.Text;
        }
    }
}