#region

using System.Windows.Input;

#endregion

namespace LCInstaller
{
    /// <summary>
    ///     Interaction logic for VersionSelect.xaml
    /// </summary>
    public partial class VersionSelect
    {
        public VersionSelect()
        {
            InitializeComponent();
        }

        public static string Version { get; set; }

        private new void MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}