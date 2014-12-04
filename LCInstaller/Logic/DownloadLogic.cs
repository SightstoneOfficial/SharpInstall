#region

using System;
using System.Diagnostics;
using System.IO;
using System.Timers;

#endregion

namespace LCInstaller.Logic
{
    public class DownloadLogic
    {
        /// <summary>
        ///     Ultra smart way to start the installer as admin without using a new program
        /// </summary>
        public static void DownloadAdmin()
        {
            string[] args = {"Admin", Logic.DlLink, Logic.InstallDirectory};

            var program = new ProcessStartInfo
            {
                FileName = Path.Combine(Logic.ExecutingDirectory, "LCInstaller.exe"),
                Arguments = "\"" + args[0] + "\" \"" + args[1] + "\" \"" + args[2] + "\"",
                Verb = "runas"
            };

            var p = new Process {StartInfo = program};
            p.Start();

            var t = new Timer {Interval = 500};
            t.Elapsed += t_Elapsed;
            t.Start();
        }

        public static string ConvertStringArrayToString(string[] input)
        {
            string output = null;
            foreach (string outLine in input)
            {
                output = "\"" + outLine + "\" ";
            }
            return output;
        }

        private static void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}