#region

using System.IO;
using System.Reflection;
using LCInstaller.Pages;

#endregion

namespace LCInstaller
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Logic.Logic.Window = this;
            Logic.Logic.MainContainer = Main;
            Logic.Logic.ExecutingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string[] var = Logic.Logic.e.Args;
            try
            {
                if (var[0] != "Admin")
                    return;

                Logic.Logic.DlLink = var[1];
                Logic.Logic.InstallDirectory = var[2];
                Logic.Logic.SwichPage<DownloadFiles>(false);
            }
            catch
            {
                Logic.Logic.SwichPage<MainPage>();
            }
        }
    }
}