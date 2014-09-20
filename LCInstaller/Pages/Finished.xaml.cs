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
            if (File.Exists(Path.Combine(Logic.Logic.InstallDirectory, "LCStartUpSplash.exe")))
            {
                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Path.Combine(Logic.Logic.InstallDirectory, "LCStartUpSplash.exe");
                p.Start();
                if (File.Exists(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log")))
                    File.Delete(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log"));
            }
            else if (Directory.Exists(Path.Combine(Logic.Logic.InstallDirectory, "Client")))
            {
                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.exe");
                p.Start();
                if (File.Exists(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log")))
                    File.Delete(Path.Combine(Logic.Logic.InstallDirectory, "Client", "LegendaryClient.Log"));
            }
            else
            {
                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Path.Combine(Logic.Logic.InstallDirectory, "LegendaryClient.exe");
                p.Start();
            }
            Environment.Exit(0);
        }
    }
}
