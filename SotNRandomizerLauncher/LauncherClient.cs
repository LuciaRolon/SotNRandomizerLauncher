using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace SotNRandomizerLauncher
{
    internal static class LauncherClient
    {
        public static string GetAPIUrl()
        {
            return "http://35.208.162.255:8080";
        }
        public static void RequestAndStoreFile(string fileRequested, string fileExtension, string folder)
        {
            try
            {
                // Get the file name from the selected file path
                string selectedFilePath = RequestFile(fileRequested, fileExtension);
                string fileName = Path.GetFileName(selectedFilePath);

                // Get the current application directory
                string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
                Directory.CreateDirectory(Path.Combine(currentAppDirectory, "files", folder));
                // Combine the current app directory with the selected file name to get the destination path
                string destinationPath = Path.Combine(currentAppDirectory, "files", folder, fileName);

                // Copy the selected file to the destination path
                File.Copy(selectedFilePath, destinationPath, true);

                Console.WriteLine($"File copied to: {destinationPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying file: {ex.Message}");
            }
        }

        public static string RequestFile(string fileRequested, string fileExtension)
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set properties of the OpenFileDialog
            openFileDialog.InitialDirectory = @"C:\"; // Set initial directory
            openFileDialog.Title = $"Select your {fileRequested}"; // Set dialog title
            openFileDialog.Filter = $"{fileExtension.ToUpper()} files (*.{fileExtension})|*.{fileExtension}"; // Filter files

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                return openFileDialog.FileName;                
            }
            else
            {
                return "";
            }            
        }


        public static bool RandomizeGame(string ppfFile, ProgressBar progressBar, Label statusLabel)
        {
            progressBar.Value = 10;
            statusLabel.Text = "Creating directory...";
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string randomPath = Path.Combine(currentAppDirectory, "files", "randomized");
            Directory.CreateDirectory(randomPath);
            

            // First we need to copy the vanilla files, starting from Track 2 & CUE since they're static
            progressBar.Value = 20;
            statusLabel.Text = "Copying vanilla files to directory...";
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string track2Path = configs.AppSettings.Settings["Track2Path"].Value;            
            string cuePath = configs.AppSettings.Settings["CuePath"].Value;
            string track2FileName = Path.GetFileName(track2Path);
            string cueFileName = Path.GetFileName(cuePath);
            File.Copy(track2Path, Path.Combine(randomPath, track2FileName), true);
            File.Copy(cuePath, Path.Combine(randomPath, cueFileName), true);

            // Then we copy the vanilla track 1 and start randomization
            string track1Path = configs.AppSettings.Settings["Track1Path"].Value;
            string track1FileName = Path.GetFileName(track1Path);
            File.Copy(track1Path, Path.Combine(randomPath, track1FileName), true);

            // Randomization Process
            progressBar.Value = 40;
            statusLabel.Text = "Applying PPF...";
            ExecuteCommand($"\"applyppf3_vc.exe\" a \"files/randomized/{track1FileName}\" \"{ppfFile}\"", "PPF Patching");
            progressBar.Value = 75;
            statusLabel.Text = "Executing final touch...";
            ExecuteCommand($"\"error_recalc.exe\" \"files/randomized/{track1FileName}\" \"{ppfFile}\"", "ECC Recalculation");

            progressBar.Value = 100;
            statusLabel.Text = "Game randomized.";
            return true;
        }

        private static void ExecuteCommand(string command, string context)
        {
            // Create a new process to run the command
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe"; // Specify the command interpreter
            process.StartInfo.Arguments = $"/c cd {currentAppDirectory} && {command}"; // Pass the command as an argument
            process.StartInfo.UseShellExecute = false; // Do not use the system shell to execute the command
            process.StartInfo.RedirectStandardOutput = true; // Redirect the standard output for capturing
            process.StartInfo.CreateNoWindow = true;
            process.Start(); // Start the process

            // Read the output of the process (if needed)
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);          

            process.WaitForExit(); // Wait for the process to exit

            // Check the exit code of the process
            int exitCode = process.ExitCode;
            Console.WriteLine($"Command exited with code {exitCode}");
            if (output.Contains("error"))
            {
                throw new RandomizerException($"Error during process: {context}. Code: {exitCode}");
            }

            // Close the process
            process.Close();
        }

        public async static Task DownloadLiveSplit()
        {
            frmDownload downloadForm = new frmDownload();
            downloadForm.Show();
            await Task.Run(() => DownloadLiveSplitApp(downloadForm));
        }

        public async static Task UpdateLiveSplit()
        {
            frmDownload downloadForm = new frmDownload();
            downloadForm.Show();

            await Task.Run(() => UpdateLiveSplitApp(downloadForm));
        }

        public static async Task DownloadBizHawk()
        {
            frmDownload downloadForm = new frmDownload();
            downloadForm.Show();
            await Task.Run(() => DownloadBizhawkApp(downloadForm));
        }

        public async static Task UpdateBizHawk()
        {
            frmDownload downloadForm = new frmDownload();
            downloadForm.Show();

            await Task.Run(() => UpdateBizhawkApp(downloadForm));
        }

        public async static Task DownloadRandoTools()
        {
            frmDownload downloadForm = new frmDownload();
            downloadForm.Show();

            await Task.Run(() => DownloadRandoToolsApp(downloadForm));
        }

        public async static Task UpdateRandoTools()
        {
            frmDownload downloadForm = new frmDownload();
            downloadForm.Show();

            await Task.Run(() => UpdateRandoToolsApp(downloadForm));
        }


        #region ConfigOperations
        private static bool ApplyLiveSplitSettings(string targetDirectory)
        {
            // Apply base files and settings
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string lssTargetPath = Path.Combine(targetDirectory, "Castlevania Symphony of the Night.lss");
            string lslTargetPath = Path.Combine(targetDirectory, "LiveSplitLayout.lsl");
            string cfgTargetPath = Path.Combine(targetDirectory, "settings.cfg");
            File.Copy(Path.Combine(currentAppDirectory, "baseFiles", "Castlevania Symphony of the Night.lss"), lssTargetPath, true);
            File.Copy(Path.Combine(currentAppDirectory, "baseFiles", "LiveSplitLayout.lsl"), lslTargetPath, true);
            File.Copy(Path.Combine(currentAppDirectory, "baseFiles", "settings.cfg"), cfgTargetPath, true);
            ModifyConfigFile(
                cfgTargetPath,
                "SplitsFile",
                $"<SplitsFile gameName=\"Castlevania: Symphony of the Night\" categoryName=\"\" lastTimingMethod=\"RealTime\" lastHotkeyProfile=\"Default\">{lssTargetPath}</SplitsFile>"
            );
            ModifyConfigFile(
                cfgTargetPath,
                "LayoutPath",
                $"<LayoutPath>{lslTargetPath}</LayoutPath>"
            );
            return true;
        }

        private static bool ApplyBizHawkSettings(string targetDirectory)
        {
            // Apply base files and settings
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Store SaveRAM
            string saveRamPath = Path.Combine(targetDirectory, "PSX", "SaveRAM");
            Directory.CreateDirectory(saveRamPath);
            string saveRamFilePath = Path.Combine(saveRamPath, "Castlevania - Symphony of the Night (USA).SaveRAM");
            // Apply Config
            string cfgTargetPath = Path.Combine(targetDirectory, "config.ini");
            string autosplitterTargetPath = Path.Combine(targetDirectory, "PSX-Autosplitter.lua");
            File.Copy(Path.Combine(currentAppDirectory, "baseFiles", "Castlevania - Symphony of the Night (USA).SaveRAM"), saveRamFilePath, true);
            File.Copy(Path.Combine(currentAppDirectory, "baseFiles", "config.ini"), cfgTargetPath, true);
            File.Copy(Path.Combine(currentAppDirectory, "baseFiles", "PSX-Autosplitter.lua"), autosplitterTargetPath, true);
            string randomPath = Path.Combine(currentAppDirectory, "files", "randomized", "Castlevania - Symphony of the Night (USA).cue");
            randomPath = randomPath.Replace(@"\", @"\\");
            autosplitterTargetPath = autosplitterTargetPath.Replace(@"\", @"\\");
            ModifyConfigFile(
                cfgTargetPath,
                "OpenRom",
                $"      \"*OpenRom*{randomPath}\""
            );
            ModifyConfigFile(
                cfgTargetPath,
                "LUASCRIPTEDIT",
                $"      \"{autosplitterTargetPath}\""
            );
            // Install BIOS
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string biosPath = configs.AppSettings.Settings["BiosPath"].Value;
            File.Copy(biosPath, Path.Combine(targetDirectory, "Firmware", "scph7003.bin"), true);

            return true;
        }

        private static bool ApplyRandoToolsSettings(string targetDirectory)
        {
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string bizHawkDirectory = Path.Combine(currentAppDirectory, "apps", "BizHawk");

            CopyDirectory(targetDirectory, bizHawkDirectory);
            return true;
        }
        #endregion


        #region DownloadWorkers


        private static void UpdateLiveSplitApp(object obj)
        {
            frmDownload downloadForm = (frmDownload)obj;
            BaseUpdateApp(downloadForm, "LiveSplit", "LiveSplit/LiveSplit", "LiveSplit");
        }

        private static void DownloadLiveSplitApp(object obj)
        {
            frmDownload downloadForm = (frmDownload)obj;            
            BaseDownloadApp(downloadForm, "LiveSplit", "LiveSplit/LiveSplit", "LiveSplit", ApplyLiveSplitSettings);
        }

        private static void UpdateBizhawkApp(object obj)
        {
            frmDownload downloadForm = (frmDownload)obj;
            BaseUpdateApp(downloadForm, "BizHawk", "TASEmulators/BizHawk", "win");
        }

        private static void DownloadBizhawkApp(object obj)
        {
            frmDownload downloadForm = (frmDownload)obj;
            BaseDownloadApp(downloadForm, "BizHawk", "TASEmulators/BizHawk", "win", ApplyBizHawkSettings);
        }

        private static void DownloadRandoToolsApp(object obj)
        {
            frmDownload downloadForm = (frmDownload)obj;
            BaseDownloadApp(downloadForm, "RandoTools", "TalicZealot/SotnRandoTools", "SotnRandoTools", ApplyRandoToolsSettings);
        }

        private static void UpdateRandoToolsApp(object obj)
        {
            frmDownload downloadForm = (frmDownload)obj;
            BaseDownloadApp(downloadForm, "RandoTools", "TalicZealot/SotnRandoTools", "Update", ApplyRandoToolsSettings);
        }

        private static string BaseUpdateApp(frmDownload downloadForm, string appName, string project, string expectedFile)
        {
            downloadForm.UpdateDownload(0, $"Fetching latest {appName} version...");
            // Get the download URL of the latest LiveSplit release
            string downloadUrl = FetchLatest(project, expectedFile, appName);


            // Download LiveSplit
            downloadForm.UpdateDownload(5, $"Downloading {appName}...");
            WebClient downloadClient = new WebClient();
            downloadClient.DownloadFile(new Uri(downloadUrl), $"{appName.ToLower()}_latest.zip");

            // Extract the app into the corresponding folder
            downloadForm.UpdateDownload(60, $"Installing {appName}...");
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string targetDirectory = Path.Combine(currentAppDirectory, "apps", appName);
            Directory.CreateDirectory(targetDirectory);
            ExtractZipWithOverwrite(Path.Combine(currentAppDirectory, $"{appName.ToLower()}_latest.zip"), targetDirectory);
            //ZipFile.ExtractToDirectory(Path.Combine(currentAppDirectory, $"{appName.ToLower()}_latest.zip"), targetDirectory);
            File.Delete(Path.Combine(currentAppDirectory, $"{appName.ToLower()}_latest.zip"));

            downloadForm.UpdateDownload(100, "Download Complete!");
            return targetDirectory;
        }

        private static void BaseDownloadApp(frmDownload downloadForm, string appName, string project, string expectedFile, Func<string, bool> configOperation)
        {
            // Download the app
            string targetDirectory = BaseUpdateApp(downloadForm, appName, project, expectedFile);
            downloadForm.UpdateDownload(80, "Applying base Settings...");
            // Then apply base settings
            configOperation(targetDirectory);
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configs.AppSettings.Settings.Remove($"{appName}Path");
            configs.AppSettings.Settings.Add($"{appName}Path", targetDirectory);
            configs.Save();

            downloadForm.UpdateDownload(100, "Download Complete!");
        }

        private static string FetchLatest(string project, string expectedFile, string appName)
        {
            // Bizhawk: TASEmulators/BizHawk
            // LiveSplit: LiveSplit/LiveSplit
            // RandoTools: TalicZealot/SotnRandoTools
            string apiUrl = $"{GetAPIUrl()}/latest/{project}";
            string downloadUrl = "";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    // Parse jsonString to get the latest release information
                    // For simplicity, let's assume it's JSON and deserialize it
                    dynamic release = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
                    string releaseVersion = release.name;
                    LauncherClient.SetAppConfig($"{appName}Version", releaseVersion);
                    
                    foreach(var asset in release.assets)
                    {
                        string assetName = asset.name;
                        if (assetName.Contains(expectedFile) && !assetName.Contains("Linux"))
                        {
                            downloadUrl = asset.browser_download_url;
                            break;
                        }
                    }
                }
            }
            return downloadUrl;
        }

        public static string GetLatestVersion(string project)
        {
            // Bizhawk: TASEmulators/BizHawk
            // LiveSplit: LiveSplit/LiveSplit
            // RandoTools: TalicZealot/SotnRandoTools
            string apiUrl = $"{GetAPIUrl()}/latest/{project}";
            string releaseVersion = "";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    dynamic release = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
                    releaseVersion = release.name;
                    return releaseVersion;
                }
            }        
            return releaseVersion;
        }

        #endregion

        #region UtilityMethods
        private static void ModifyConfigFile(string filePath, string modifySearch, string newLine)
        {
            // Read all lines from the config file
            string[] lines = File.ReadAllLines(filePath);

            // Find the line to modify
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(modifySearch))
                {
                    // Modify the content of the line
                    lines[i] = newLine;
                    break; // Exit the loop once the line is modified
                }
            }

            // Write the modified lines back to the config file
            File.WriteAllLines(filePath, lines);
        }

        static void ExtractZipWithOverwrite(string zipFilePath, string extractPath)
        {
            // Ensure the target directory exists
            if (!Directory.Exists(extractPath))
            {
                Directory.CreateDirectory(extractPath);
            }

            // Extract the contents of the ZIP file
            using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    string entryPath = Path.Combine(extractPath, entry.FullName);

                    // If the entry is a directory, create it
                    if (entry.FullName.EndsWith("/") || entry.FullName.EndsWith("\\"))
                    {
                        Directory.CreateDirectory(entryPath);
                    }
                    else
                    {
                        // Delete the existing file if it exists
                        if (File.Exists(entryPath))
                        {
                            File.Delete(entryPath);
                        }

                        // Extract the entry
                        entry.ExtractToFile(entryPath);
                    }
                }
            }
        }

        static void CopyDirectory(string sourceDir, string targetDir)
        {
            // Create the target directory if it doesn't exist
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            // Get the subdirectories of the source directory
            string[] subDirectories = Directory.GetDirectories(sourceDir);

            // Copy files in the source directory
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(targetDir, fileName);
                File.Copy(file, destFile, true); // Set overwrite to true to overwrite existing files
            }

            // Recursively copy subdirectories
            foreach (string subDir in subDirectories)
            {
                string subDirName = Path.GetFileName(subDir);
                string targetSubDir = Path.Combine(targetDir, subDirName);
                CopyDirectory(subDir, targetSubDir);
            }
        }

        public static bool IsInitialSetup()
        {
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return configs.AppSettings.Settings["InitialSetupCheck"] == null;
        }

        public static void InitialSetupDone()
        {
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configs.AppSettings.Settings.Add("InitialSetupCheck", "Done");
            configs.Save();
            DialogResult result = MessageBox.Show("It seems this is the first time you're using the Launcher. Do you want to check our Tutorials?", "Welcome to SotN Randomizer!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);            
            if(result == DialogResult.Yes)
            {
                frmTutorials frmTutorials = new frmTutorials();
                frmTutorials.ShowDialog();
            }
        }

        public static void SetAppConfig(string key, string value)
        {
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configs.AppSettings.Settings.Remove(key);
            configs.AppSettings.Settings.Add(key, value);
            configs.Save();
        }

        public static string GetConfigValue(string config)
        {
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (configs.AppSettings.Settings[config] != null)
            {
                // Key exists, so access its value
                string value = configs.AppSettings.Settings[config].Value;
                return value;
            }
            return null;
        }

        public static string GetConfigValue(Configuration configs, string config)
        {
            if (configs.AppSettings.Settings[config] != null)
            {
                // Key exists, so access its value
                string value = configs.AppSettings.Settings[config].Value;
                return value;
            }
            return null;
        }

        public static Dictionary<string, string> LoadCurrentEvent()
        {
            string apiUrl = $"{GetAPIUrl()}/events/current";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
                    string eventTitle = result.event_title;
                    string eventSubtitle = result.event_subtitle;
                    Dictionary<string, string> resultDict = new Dictionary<string, string>
                    {
                        { "EventTitle", eventTitle },
                        { "EventSubtitle", eventSubtitle }
                    };
                    return resultDict;
                }
            }
            return null;
        }

        public static Dictionary<string, string> LoadSeedOfTheWeek()
        {
            string apiUrl = $"{GetAPIUrl()}/events/week_seed";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
                    string presetName = result.preset_name;
                    string seedUrl = result.seed_link;
                    Dictionary<string, string> resultDict = new Dictionary<string, string>
                    {
                        { "PresetName", presetName },
                        { "SeedURL", seedUrl }
                    };
                    return resultDict;
                }
            }
            return null;
        }
        #endregion
    }
}
