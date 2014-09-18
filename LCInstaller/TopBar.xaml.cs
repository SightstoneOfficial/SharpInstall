using LCInstaller.Pages;
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

namespace LCInstaller
{
    /// <summary>
    /// Interaction logic for TopBar.xaml
    /// </summary>
    public partial class TopBar : UserControl
    {
        public TopBar()
        {
            InitializeComponent();
            Label.Content = "LegendaryClient Installer";
        }
        private void DragGrid(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                Logic.Logic.Window.DragMove();
        }
        private void Minimize(object sender, RoutedEventArgs e)
        {
            Logic.Logic.Window.WindowState = WindowState.Minimized;
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            if (!Logic.Logic.Installed)
                Logic.Logic.SwichPage<CloseInstall>();
            if (Logic.Logic.Installed)
                Environment.Exit(0);
        }
    }
}
