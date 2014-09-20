using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LCInstaller.Logic
{
    public class DownloadLogic
    {
        /// <summary>
        /// Ultra smart way to start the installer as admin without using a new program
        /// </summary>
        public static void DownloadAdmin()
        {
            ProcessStartInfo program = new ProcessStartInfo();
            program.FileName = Path.Combine(Logic.ExecutingDirectory, "LCInstaller.exe");
            string[] args = {"Admin", Logic.DlLink, Logic.InstallDirectory};
            program.Arguments = "\"" + args[0] + "\" \""+ args[1] + "\" \"" + args[2] + "\"";
            program.Verb = "runas";
            var p = new System.Diagnostics.Process();
            p.StartInfo = program;
            p.Start();

            Timer t = new Timer();
            t.Interval = 500;
            t.Elapsed += t_Elapsed;
            t.Start();
        }
        public static string ConvertStringArrayToString(string[] input)
        {
            string output = null;
            foreach (string OutLine in input)
            {
                if (output == null)
                {
                    output = "\"" + OutLine + "\" ";
                }
                else
                {
                    output = "\"" + OutLine + "\" ";
                }
            }
            return output;
        }

        static void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
