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
    /// Interaction logic for CloseInstall.xaml
    /// </summary>
    public partial class CloseInstall : Page
    {
        public CloseInstall()
        {
            InitializeComponent();
            Text.Text = "LegendaryClient is not finished installing" + Environment.NewLine +
                "Are you sure you want to cancel the installation of LegendaryClient?";
        }
        private void Return(object sender, RoutedEventArgs e)
        {
            Logic.Logic.AbortQuit();
        }
        private void Quit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
