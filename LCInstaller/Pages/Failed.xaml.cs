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
    /// Interaction logic for Failed.xaml
    /// </summary>
    public partial class Failed : Page
    {
        public Failed()
        {
            InitializeComponent();
            Logic.Logic.Installed = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
