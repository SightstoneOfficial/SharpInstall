using LCInstaller.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Permissions;
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
    /// Interaction logic for DownloadFiles.xaml
    /// </summary>
    public partial class DownloadFiles : Page
    {        
        public DownloadFiles()
        {
            InitializeComponent();
            Link.Content = Logic.Logic.DlLink;
            Download();
        }
        private void Download()
        {
            using (WebClient client = new WebClient())
            {
                Directory.CreateDirectory(Path.Combine(Logic.Logic.InstallDirectory, "temp"));
                client.DownloadFileAsync(new Uri(Logic.Logic.DlLink), System.IO.Path.Combine(Logic.Logic.InstallDirectory, "temp", "LegendaryClient.zip"));
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
            }
        }

        static void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ZipFile.ExtractToDirectory(System.IO.Path.Combine(Logic.Logic.InstallDirectory, "temp", "LegendaryClient.zip"), Logic.Logic.InstallDirectory);
            Logic.Logic.Installed = true;
            Logic.Logic.SwichPage<Finished>();
            Directory.Delete(Path.Combine(Logic.Logic.InstallDirectory, "temp"), true);
            var x = Path.Combine(Logic.Logic.InstallDirectory, "Client", "LC", "Version.Version");
            var l = Path.Combine(Logic.Logic.InstallDirectory, "Client", "LC");
            if (!Directory.Exists(l))
                Directory.CreateDirectory(l);
            if (!File.Exists(x))
            {
                //Write the version to the file
                var y = File.Create(x);
                y.Close();
                StreamWriter writer = new StreamWriter(x);
                writer.Write(Logic.Logic.Version);
                writer.Close(); 
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            Bytes.Content = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
            int half = int.Parse(Math.Truncate(percentage).ToString());
            Progress.Value = half;
            DownloadFull.Content = half + "% finished of the total install";
        }
    }
}
