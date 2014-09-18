using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCInstaller.Logic
{
    public class LCVersions
    {
        public static string VersionId { get; set; }
        public static string VersionName { get; set; }
        public static string VersionDescription { get; set; }
        public static string DownloadLink { get; set; }
        public static bool IsPrerelease { get; set; }
        public static bool IsBeta { get; set; }
    }
    public class LCVersionList
    {
        List<LCVersions> VersionList;
    }
}
