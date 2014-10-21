using LCInstaller.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace LCInstaller.Logic
{
    public class Logic
    {
        internal static MainWindow Window;
        internal static ContentControl MainContainer;
        private static Type CurrentPage;
        private static Type QuitPage;
        internal static StartupEventArgs e;
        public static String ExecutingDirectory;
        public static String InstallDirectory;
        public static String DlLink;
        public static String Version;

        internal static bool Installed = false;

        internal static void AbortQuit(params object[] Arguments)
        {
            Page instance = (Page)Activator.CreateInstance(QuitPage, Arguments);
            var fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
            fadeOutAnimation.Completed += (x, y) =>
            {
                MainContainer.Content = instance.Content;
                var fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.25));
                MainContainer.BeginAnimation(ContentControl.OpacityProperty, fadeInAnimation);
            };
            MainContainer.BeginAnimation(ContentControl.OpacityProperty, fadeOutAnimation);
            CurrentPage = QuitPage;
        }
        internal static void SwichPage<T>(bool Fade = true, params object[] Arguments)
        {
            if (CurrentPage == typeof(T))
                return;

            if (typeof(T) == typeof(CloseInstall))
                QuitPage = CurrentPage;

            Page instance = (Page)Activator.CreateInstance(typeof(T), Arguments);
            CurrentPage = typeof(T);

            if (Fade)
            {
                var fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
                fadeOutAnimation.Completed += (x, y) =>
                {
                    MainContainer.Content = instance.Content;
                    var fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.25));
                    MainContainer.BeginAnimation(ContentControl.OpacityProperty, fadeInAnimation);
                };
                MainContainer.BeginAnimation(ContentControl.OpacityProperty, fadeOutAnimation);
            }
            else
            {
                MainContainer.Content = instance.Content;
            }
        }

    }
}
