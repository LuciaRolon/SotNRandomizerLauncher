using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    internal static class UpdateHandler
    {
        public static int GetCurrentVersion()
        {
            return 4; // Must be updated with every release
        }

        private static int GetInstalledVersion()
        {
            string ver = LauncherClient.GetConfigValue("LauncherVersion");
            int version = 0;
            if (ver != null)
            {
                version = int.Parse(ver);
            }
            return version;
        }

        private static void SetInstalledVersion(int version)
        {
            LauncherClient.SetAppConfig("LauncherVersion", version.ToString());
        }
        public static void UpdateLauncher()
        {
            int installedVersion = GetInstalledVersion();
            int latestVersion = GetCurrentVersion();
            int installedTo = 0;
            if (installedVersion == latestVersion) return;

            for(int i = installedVersion + 1; i <= latestVersion; i++)
            {
                RunUpdateForVersion(i);
                installedTo = i;
            }
            SetInstalledVersion(installedTo);
        }

        static void RunUpdateForVersion(int version)
        {
            switch (version)
            {
                case 2:
                    Version2();
                    break;
            }
        }

        static void Version2()
        {
            // Sets up the files for the Fast Core
            string bizHawkDirectory = LauncherClient.GetConfigValue("BizHawkPath");
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            LauncherClient.StoreCores(currentAppDirectory, bizHawkDirectory);
        }
    }
}
