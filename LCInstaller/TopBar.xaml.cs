#region

using System;
using System.Windows;
using System.Windows.Input;
using LCInstaller.Pages;

#endregion

namespace LCInstaller
{
    /// <summary>
    ///     Interaction logic for TopBar.xaml
    /// </summary>
    public partial class TopBar
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