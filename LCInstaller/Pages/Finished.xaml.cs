#region

using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using IWshRuntimeLibrary;
using File = System.IO.File;

#endregion

namespace LCInstaller.Pages
{
    /// <summary>
    ///     Interaction logic for Finished.xaml
    /// </summary>
    public partial class Finished
    {
        public Finished()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Path.Combine(Logic.Logic.InstallDirectory, "LCStartUpSplash.exe")))
            {
                var p = new Process
                {
                    StartInfo = {FileName = Path.Combine(Logic.Logic.InstallDirectory, "LCStartUpSplash.exe")}
                };
                p.Start();

                if (File.Exists(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log")))
                    File.Delete(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log"));
            }
            else if (Directory.Exists(Path.Combine(Logic.Logic.InstallDirectory, "Client")))
            {
                var p = new Process
                {
                    StartInfo = {FileName = Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.exe")}
                };
                p.Start();

                if (File.Exists(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log")))
                    File.Delete(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log"));
            }
            else
            {
                var p = new Process
                {
                    StartInfo = {FileName = Path.Combine(Logic.Logic.InstallDirectory, "LegendaryClient.exe")}
                };
                p.Start();
            }
            if ((bool) Shortcut.IsChecked)
            {
                string shortcutLocation =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                        "LegenadryClient" + ".lnk");
                var shell = new WshShell();
                var shortcut = (IWshShortcut) shell.CreateShortcut(shortcutLocation);

                shortcut.TargetPath = Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.exe");
                shortcut.Save();
            }
            Environment.Exit(0);
        }
    }
}