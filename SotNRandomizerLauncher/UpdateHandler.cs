using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    internal static class UpdateHandler
    {
        public static int GetCurrentVersion()
        {
            return 9; // Must be updated with every release
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
                case 5:
                    Version5();
                    break;
                case 6:
                    Version6();
                    break;
                case 7:
                    Version7();
                    break;
                case 8:
                    Version8();
                    break;
                case 9:
                    Version9();
                    break;
            }
        }

        static void Version6()
        {
            // Sets up the files for the Fast Core
            string bizHawkDirectory = LauncherClient.GetConfigValue("BizHawkPath");
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            LauncherClient.StoreCores(currentAppDirectory, bizHawkDirectory);
            LauncherClient.SwapCores(false, false, false);
            MessageBox.Show("This update has reset your core back to Classic Core. If you want to use the Fast Core, swap it again in the Settings.", "Update Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void Version5()
        {
            LauncherClient.SetAppConfig("RandoToolsVersion", "1.6.9");
        }

        static void Version7()
        {
            LauncherClient.InstallAreaRando();
            string bizHawkDirectory = LauncherClient.GetConfigValue("BizHawkPath");
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            LauncherClient.StoreCompatCore(currentAppDirectory, bizHawkDirectory);
        }

        static void Version8()
        {
            LauncherClient.InstallAreaRando();
        }

        static void Version9()
        {
            LauncherClient.InstallMapTracker();
        }
    }
}
