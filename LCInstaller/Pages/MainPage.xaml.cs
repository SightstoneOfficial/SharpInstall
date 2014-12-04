#region

using System;
using System.Deployment.Application;
using System.Reflection;
using System.Windows;

#endregion

namespace LCInstaller.Pages
{
    /// <summary>
    ///     Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Text.Text = "LegendaryClient Installer Version " + CurrentVersion + Environment.NewLine +
                        Environment.NewLine +
                        "Please note that this program will: " + Environment.NewLine +
                        "1. Install LegendaryClient onto your computer." + Environment.NewLine +
                        "2. Need an internet connection." + Environment.NewLine +
                        "3. Should be installed with net 4.5.1" + Environment.NewLine +
                        Environment.NewLine +
                        "Please note that this program may impact performance on your computer" + Environment.NewLine +
                        Environment.NewLine +
                        "Eddy5641 is not reponsible for the program installed if you did not download it" +
                        Environment.NewLine + "from:" + Environment.NewLine +
                        "https://github.com/eddy5641/LegendaryClient" + Environment.NewLine +
                        "Please insure that you do not have a modified version and got it from this link" +
                        Environment.NewLine +
                        "If your account gets hacked, do not contact me if you used a different client not" +
                        Environment.NewLine +
                        "downloaded from the specifed link or if you used a different client" + Environment.NewLine +
                        Environment.NewLine +
                        "In the case your account gets hacked and you do not fall under the previously" +
                        Environment.NewLine +
                        "stated contact me at: ic.eddy5641@gmail.com" + Environment.NewLine + Environment.NewLine +
                        "LegendaryClient, improving League Of Legends for today and tomorrow";
            Text.IsEnabled = false;
        }

        /// <summary>
        ///     Get Current Version of the Installer
        /// </summary>
        public string CurrentVersion
        {
            get
            {
                return (ApplicationDeployment.IsNetworkDeployed
                    ? ApplicationDeployment.CurrentDeployment.CurrentVersion
                    : Assembly.GetExecutingAssembly().GetName().Version).ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logic.Logic.SwichPage<InstallLocation>();
        }
    }
}