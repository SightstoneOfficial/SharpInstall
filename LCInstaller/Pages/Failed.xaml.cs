#region

using System;
using System.Windows;

#endregion

namespace LCInstaller.Pages
{
    /// <summary>
    ///     Interaction logic for Failed.xaml
    /// </summary>
    public partial class Failed
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