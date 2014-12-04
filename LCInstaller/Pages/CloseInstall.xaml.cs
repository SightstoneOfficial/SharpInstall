#region

using System;
using System.Windows;

#endregion

namespace LCInstaller.Pages
{
    /// <summary>
    ///     Interaction logic for CloseInstall.xaml
    /// </summary>
    public partial class CloseInstall
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