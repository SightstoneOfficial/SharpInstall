using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace LCInstaller.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Text.Text = "LegendaryClient Installer Version 1.0.0.0" + Environment.NewLine + 
                "Please note that this program will: " + Environment.NewLine +
                "1. Install LegendaryClient onto your computer." + Environment.NewLine + 
                "2. Need an internet connection." + Environment.NewLine + 
                "3. Should be installed with net 4.5.1"  + Environment.NewLine  + Environment.NewLine + 
                "Please note that this program may impact performance on your computer" + Environment.NewLine  + Environment.NewLine +
                "Eddy5641 is not reponsible for the program installed if you did not download it" + Environment.NewLine + "from:" + Environment.NewLine +
                "https://github.com/eddy5641/LegendaryClient"+ Environment.NewLine +
                "Please insure that you do not have a modified version and got it from this link" + Environment.NewLine +
                "If your account gets hacked, do not contact me if you used a different client not" + Environment.NewLine + 
                "downloaded from the specifed link or if you used a different client" + Environment.NewLine +  Environment.NewLine + 
                "In the case your account gets hacked and you do not fall under the previously" +  Environment.NewLine +
                "stated contact me at: ic.eddy5641@gmail.com" + Environment.NewLine + Environment.NewLine +
                "LegendaryClient, improving League Of Legends for today and tomorrow";
            Text.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logic.Logic.SwichPage<InstallLocation>();
        }
    }
}
