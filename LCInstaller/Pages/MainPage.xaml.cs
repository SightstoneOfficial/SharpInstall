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
                "Please note that this program may impact performance on your computer";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logic.Logic.SwichPage<DownloadFiles>();
        }
    }
}
