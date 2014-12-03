#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using LCInstaller.Pages;

#endregion

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

        internal static void AbortQuit(params object[] args)
        {
            var instance = (Page) Activator.CreateInstance(QuitPage, args);
            var fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
            fadeOutAnimation.Completed += (x, y) =>
            {
                MainContainer.Content = instance.Content;
                var fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.25));
                MainContainer.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
            };
            MainContainer.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
            CurrentPage = QuitPage;
        }

        internal static void SwichPage<T>(bool fade = true, params object[] args)
        {
            if (CurrentPage == typeof (T))
                return;

            if (typeof (T) == typeof (CloseInstall))
                QuitPage = CurrentPage;

            var instance = (Page) Activator.CreateInstance(typeof (T), args);
            CurrentPage = typeof (T);

            if (fade)
            {
                var fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
                fadeOutAnimation.Completed += (x, y) =>
                {
                    MainContainer.Content = instance.Content;
                    var fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.25));
                    MainContainer.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
                };
                MainContainer.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
            }
            else
            {
                MainContainer.Content = instance.Content;
            }
        }
    }
}