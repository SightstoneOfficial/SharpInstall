#region

using System.Collections.Generic;

#endregion

namespace LCInstaller.Logic
{
    public class LCVersions
    {
        public string VersionId { get; set; }
        public string VersionName { get; set; }
        public string VersionDescription { get; set; }
        public string DownloadLink { get; set; }
        public bool IsPrerelease { get; set; }
        public bool IsBeta { get; set; }
    }

    public class LCVersionList
    {
        public List<LCVersions> LCVersions;
    }
}