#region

using System.Windows;

#endregion

namespace LCInstaller
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Logic.Logic.e = e;
        }
    }
}