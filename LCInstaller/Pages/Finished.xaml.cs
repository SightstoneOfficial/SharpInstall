using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace LCInstaller.Pages
{
    /// <summary>
    /// Interaction logic for Finished.xaml
    /// </summary>
    public partial class Finished : Page
    {
        public Finished()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(Path.Combine(Logic.Logic.InstallDirectory, "LCStartUpSplash.exe")))
            {
                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Path.Combine(Logic.Logic.InstallDirectory, "LCStartUpSplash.exe");
                p.Start();
                if (System.IO.File.Exists(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log")))
                    System.IO.File.Delete(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log"));
            }
            else if (Directory.Exists(Path.Combine(Logic.Logic.InstallDirectory, "Client")))
            {
                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.exe");
                p.Start();
                if (System.IO.File.Exists(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log")))
                    System.IO.File.Delete(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log"));
            }
            else
            {
                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Path.Combine(Logic.Logic.InstallDirectory, "LegendaryClient.exe");
                p.Start();
            }
            if ((bool)Shortcut.IsChecked)
            {
                string shortcutLocation = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "LegenadryClient" + ".lnk");
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

                shortcut.TargetPath = Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.exe");
                shortcut.Save();   
            }
            Environment.Exit(0);
        }
    }
}
