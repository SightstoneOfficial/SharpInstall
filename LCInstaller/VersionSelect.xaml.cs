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
    /// Interaction logic for VersionSelect.xaml
    /// </summary>
    public partial class VersionSelect : UserControl
    {
        public VersionSelect()
        {
            InitializeComponent();
        }

        public static string Version { get; set; }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
