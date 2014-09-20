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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Logic.Logic.Window = this;
            Logic.Logic.MainContainer = Main;
            Logic.Logic.ExecutingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var var = Logic.Logic.e.Args;
            try
            {                
                if (var[0] == "Admin")
                {
                    Logic.Logic.DlLink = var[1];
                    Logic.Logic.InstallDirectory = var[2];
                    Logic.Logic.SwichPage<DownloadFiles>(false);
                }
            }
            catch
            {
                Logic.Logic.SwichPage<MainPage>();
            }
        }
    }
}
