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
            return 2; // Must be updated with every release
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
                case 1:
                    Version1();
                    break;
                case 2:
                    Version2();
                    break;
            }
        }

        static void Version1()
        {
            // Installs the Preset Files
            if (LauncherClient.GetConfigValue("ImportedUser") != null)
            {
                DialogResult result = MessageBox.Show("This update includes a few changes to RandoTools presets. Do you want to install them? Yes to Install, No to ignore this update.", "Imported User Update Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }

            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string bizHawkDirectory = LauncherClient.GetConfigValue("BizHawkPath");
            string basePresetsPath = Path.Combine(currentAppDirectory, "baseFiles", "Presets.zip");
            string presetsPath = Path.Combine(bizHawkDirectory, "ExternalTools", "SotnRandoTools", "Presets");
            LauncherClient.ExtractZipWithOverwrite(basePresetsPath, presetsPath);
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
