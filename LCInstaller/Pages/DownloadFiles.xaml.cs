#region

using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;

#endregion

namespace LCInstaller.Pages
{
    /// <summary>
    ///     Interaction logic for DownloadFiles.xaml
    /// </summary>
    public partial class DownloadFiles
    {
        public DownloadFiles()
        {
            InitializeComponent();
            Link.Content = Logic.Logic.DlLink;
            Download();
        }

        private void Download()
        {
            using (var client = new WebClient())
            {
                Directory.CreateDirectory(Path.Combine(Logic.Logic.InstallDirectory, "temp"));

                client.DownloadFileAsync(new Uri(Logic.Logic.DlLink),
                    Path.Combine(Logic.Logic.InstallDirectory, "temp", "LegendaryClient.zip"));
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
            }
        }

        private static void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ZipFile.ExtractToDirectory(Path.Combine(Logic.Logic.InstallDirectory, "temp", "LegendaryClient.zip"),
                Logic.Logic.InstallDirectory);

            Logic.Logic.Installed = true;
            Logic.Logic.SwichPage<Finished>();

            Directory.Delete(Path.Combine(Logic.Logic.InstallDirectory, "temp"), true);

            string x = Path.Combine(Logic.Logic.InstallDirectory, "Client", "LC", "Version.Version");
            string l = Path.Combine(Logic.Logic.InstallDirectory, "Client", "LC");
            if (!Directory.Exists(l))
                Directory.CreateDirectory(l);

            if (File.Exists(x))
                return;

            //Write the version to the file
            FileStream y = File.Create(x);
            y.Close();

            var writer = new StreamWriter(x);
            writer.Write(Logic.Logic.Version);
            writer.Close();
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString(CultureInfo.InvariantCulture));
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString(CultureInfo.InvariantCulture));
            double percentage = bytesIn/totalBytes*100;

            Bytes.Content = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;

            int half = int.Parse(Math.Truncate(percentage).ToString(CultureInfo.InvariantCulture));
            Progress.Value = half;
            DownloadFull.Content = half + "% finished of the total install";
        }
    }
}