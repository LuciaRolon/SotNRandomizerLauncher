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
using System.Runtime.CompilerServices;

namespace SotNRandomizerLauncher
{
    internal struct DownloadData
    {       

        public string downloadUrl;
        public string releaseVersion;

        public DownloadData(string url, string version)
        {
            downloadUrl = url;
            releaseVersion = version;
        }
    }

    static class LauncherClient
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
            string latestPath = GetConfigValue("LastPathBrowsed");
            openFileDialog.InitialDirectory = (latestPath == null) ? @"C:\" : latestPath; // Set initial directory
            openFileDialog.Title = $"Select your {fileRequested}"; // Set dialog title
            openFileDialog.Filter = $"{fileExtension.ToUpper()} files (*.{fileExtension})|*.{fileExtension}"; // Filter files

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                SetLastBrowsed(openFileDialog.FileName);
                return openFileDialog.FileName;                
            }
            else
            {
                return "";
            }            
        }

        public static string InitiateStoreFile(string fileRequested, string suggestedFileName, string fileExtension)
        {
            // Create an instance of OpenFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set properties of the OpenFileDialog
            string latestPath = GetConfigValue("LastPathBrowsed");
            saveFileDialog.InitialDirectory = (latestPath == null) ? @"C:\" : latestPath; // Set initial directory
            saveFileDialog.Title = $"Select your {fileRequested}"; // Set dialog title
            saveFileDialog.DefaultExt = fileExtension;
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = suggestedFileName;
            saveFileDialog.Filter = $"{fileExtension.ToUpper()} files (*.{fileExtension})|*.{fileExtension}"; // Filter files

            // Show the dialog and check if the user selected a file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                SetLastBrowsed(saveFileDialog.FileName);
                return saveFileDialog.FileName;
            }
            else
            {
                return "";
            }
        }

        public static bool InstallAreaRando()
        {        
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Extract the Area Rando Tool
            string areaRandoPath = Path.Combine(currentAppDirectory, "apps", "AreaRando");
            ExtractZipWithOverwrite(Path.Combine(currentAppDirectory, "baseFiles", "AreaRando.zip"), areaRandoPath);
            LauncherClient.SetAppConfig("AreaRandoPath", areaRandoPath);            
            return true;
        }

        public static void InstallMapTracker()
        {
            // Extract the Map Tracker Tool
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string mapTrackerPath = Path.Combine(currentAppDirectory, "apps", "AreaRandoMapTracker");
            ExtractZipWithOverwrite(Path.Combine(currentAppDirectory, "baseFiles", "AreaRandoTracker.zip"), mapTrackerPath);
            LauncherClient.SetAppConfig("MapTrackerPath", mapTrackerPath);
        }

        public static async Task AsyncRandomizeGame(string ppfFile, frmMain frmMain)
        {
            await Task.Run(() => RandomizeGame(ppfFile, frmMain));
        }

        public static bool RandomizeGame(string ppfFile, frmMain frmMain)
        {
            frmMain.UpdateRandomizeStatus(10, "Creating directory...");
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string randomPath = Path.Combine(currentAppDirectory, "files", "randomized");
            Directory.CreateDirectory(randomPath);


            // First we need to copy the vanilla files, starting from Track 2 & CUE since they're static
            frmMain.UpdateRandomizeStatus(20, "Copying vanilla files to directory...");
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
            frmMain.UpdateRandomizeStatus(40, "Applying PPF...");
            ExecuteCommand($"\"applyppf3_vc.exe\" a \"files/randomized/{track1FileName}\" \"{ppfFile}\"", "PPF Patching");
            frmMain.UpdateRandomizeStatus(75, "Executing final touch...");
            ExecuteCommand($"\"error_recalc.exe\" \"files/randomized/{track1FileName}\" \"{ppfFile}\"", "ECC Recalculation");

            frmMain.UpdateRandomizeStatus(100, "Game randomized.");
            return true;
        }

        public static void PatchBinCopy(string ppfFile, string baseBinPath)
        {
            string track1Path = GetConfigValue("Track1Path");
            File.Copy(track1Path, baseBinPath, true);

            // Randomization Process
            ExecuteCommand($"\"applyppf3_vc.exe\" a \"{baseBinPath}\" \"{ppfFile}\"", "PPF Patching");
            ExecuteCommand($"\"error_recalc.exe\" \"{baseBinPath}\" \"{ppfFile}\"", "ECC Recalculation");
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

        public async static Task DownloadRandomizer()
        {
            frmDownload downloadForm = new frmDownload();
            downloadForm.Show();

            await Task.Run(() => DownloadRandomizer(downloadForm));
        }

        public async static Task DownloadPresets()
        {
            frmDownload downloadForm = new frmDownload();
            downloadForm.Show();

            await Task.Run(() => DownloadPresets(downloadForm));
        }


        public static void SwapCores(bool toFastCore, bool compatibilityCore)
        {
            try
            {
                string bizHawkDirectory = GetConfigValue("BizHawkPath");
                if (toFastCore)
                {
                    string fastCoreName = "nymafast.wbx";
                    if (compatibilityCore) fastCoreName = "nymafast-comp.wbx";
                    string oldCorePath = Path.Combine(bizHawkDirectory, "dll", "shock.wbx.zst");
                    string newCorePath = Path.Combine(bizHawkDirectory, "dll", "shock.wbx");
                    string newCoreTempFile = Path.Combine(bizHawkDirectory, "dll", fastCoreName);
                    File.Delete(oldCorePath);
                    File.Copy(newCoreTempFile, newCorePath, true);
                    SetAppConfig("CoreInstalled", "FastCore");
                }
                else
                {
                    string oldCorePath = Path.Combine(bizHawkDirectory, "dll", "shock.wbx");
                    string newCorePath = Path.Combine(bizHawkDirectory, "dll", "shock.wbx.zst");
                    string newCoreTempFile = Path.Combine(bizHawkDirectory, "dll", "nymashock.wbx.zst");
                    File.Delete(oldCorePath);
                    File.Copy(newCoreTempFile, newCorePath, true);
                    SetAppConfig("CoreInstalled", "ClassicCore");
                }
                
                MessageBox.Show("Core changed succesfully!", "Core Swap", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBox.Show($"Error swapping core: {ex.Message}", "Core Swap Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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

        public static void StoreCores(string currentAppDirectory, string targetDirectory)
        {
            string nymashockCorePath = Path.Combine(targetDirectory, "dll", "nymashock.wbx.zst");
            string nymafastCorePath = Path.Combine(targetDirectory, "dll", "nymafast.wbx");
            File.Copy(Path.Combine(currentAppDirectory, "baseFiles", "nymashock.wbx.zst"), nymashockCorePath, true);
            File.Copy(Path.Combine(currentAppDirectory, "baseFiles", "nymafast.wbx"), nymafastCorePath, true);
            SetAppConfig("CoreInstalled", "ClassicCore");
        }

        public static void StoreCompatCore(string currentAppDirectory, string targetDirectory)
        {
            string nymafastCorePath = Path.Combine(targetDirectory, "dll", "nymafast-comp.wbx");
            File.Copy(Path.Combine(currentAppDirectory, "baseFiles", "nymafast-comp.wbx"), nymafastCorePath, true);
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
            string cuePath = GetConfigValue("CuePath");
            string randomPath = Path.Combine(currentAppDirectory, "files", "randomized", Path.GetFileName(cuePath));
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
            File.Copy(biosPath, Path.Combine(targetDirectory, "Firmware", Path.GetFileName(biosPath)), true);

            return true;
        }

        private static bool ApplyRandoToolsSettings(string targetDirectory)
        {
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string bizHawkDirectory = Path.Combine(currentAppDirectory, "apps", "BizHawk");
            if (GetConfigValue("RandoToolsPath") != null) // If this is true, then it is an update.
            {
                bizHawkDirectory = Path.Combine(bizHawkDirectory, "ExternalTools");
                // Now we should delete the old "ExternalTools" folder from the source directory.
                string externalPath = Path.Combine(targetDirectory, "ExternalTools");
                if (Directory.Exists(externalPath)) Directory.Delete(externalPath, true);
            }

            CopyDirectory(targetDirectory, bizHawkDirectory);
            return true;
        }

        private static bool ApplyPresets(string targetDirectory)
        {
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string bizHawkDirectory = Path.Combine(currentAppDirectory, "apps", "BizHawk");
            string presetsPath = Path.Combine(bizHawkDirectory, "ExternalTools", "SotnRandoTools", "Presets");
            CopyDirectory(targetDirectory, presetsPath);
            return true;
        }
        #endregion

        public static void CheckForPresetUpdates()
        {
            // Checks for the latest preset updates, with the option for imported users to ignore the update until next release.
            string latestPresetsVersion = LauncherClient.GetLatestVersion("LuciaRolon/CompiledRandomizer");
            bool importedUser = LauncherClient.GetConfigValue("ImportedUser") != null;
            if (importedUser && LauncherClient.GetConfigValue("PresetsIgnoredVersion") == latestPresetsVersion) return;

            if (latestPresetsVersion != LauncherClient.GetConfigValue("PresetsVersion"))
            {
                if (importedUser)
                {
                    DialogResult resultPres = MessageBox.Show("There's an update available for RandoTools presets. Do you want to install them? Press No to ignore until next release.", "Imported User Update Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultPres == DialogResult.No)
                    {
                        LauncherClient.SetAppConfig("PresetsIgnoredVersion", latestPresetsVersion);
                        return;
                    }
                }
                RunPresetUpdates();
            }
        }

        async static void RunPresetUpdates()
        {
            await LauncherClient.DownloadPresets();
        }


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

        private static void DownloadRandomizer(object obj)
        {
            frmDownload downloadForm = (frmDownload)obj;
            string targetDirectory = BaseUpdateApp(downloadForm, "Randomizer", "LuciaRolon/CompiledRandomizer", "Randomizer", true);
            LauncherClient.SetAppConfig($"RandomizerPath", targetDirectory);
        }

        private static void DownloadPresets(object obj)
        {
            frmDownload downloadForm = (frmDownload)obj;
            BaseDownloadApp(downloadForm, "Presets", "LuciaRolon/CompiledRandomizer", "Presets", ApplyPresets);
        }


        private static string BaseUpdateApp(frmDownload downloadForm, string appName, string project, string expectedFile)
        {
            downloadForm.UpdateDownload(0, $"Fetching latest {appName} version...");
            // Get the download URL of the latest LiveSplit release
            DownloadData downloadData = FetchLatest(project, expectedFile, appName);
            string downloadUrl = downloadData.downloadUrl;
            Console.WriteLine(downloadUrl);
            string releaseVersion = downloadData.releaseVersion;

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
            LauncherClient.SetAppConfig($"{appName}Version", releaseVersion);
            return targetDirectory;
        }

        private static string BaseUpdateApp(frmDownload downloadForm, string appName, string project, string expectedFile, bool cleanDownload)
        {
            downloadForm.UpdateDownload(0, $"Fetching latest {appName} version...");
            // Get the download URL of the latest LiveSplit release
            DownloadData downloadData = FetchLatest(project, expectedFile, appName);
            string downloadUrl = downloadData.downloadUrl;
            Console.WriteLine(downloadUrl);
            string releaseVersion = downloadData.releaseVersion;

            // Download LiveSplit
            downloadForm.UpdateDownload(5, $"Downloading {appName}...");
            WebClient downloadClient = new WebClient();
            downloadClient.DownloadFile(new Uri(downloadUrl), $"{appName.ToLower()}_latest.zip");

            // Extract the app into the corresponding folder
            downloadForm.UpdateDownload(60, $"Installing {appName}...");
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string targetDirectory = Path.Combine(currentAppDirectory, "apps", appName);
            if (cleanDownload && Directory.Exists(targetDirectory))
            {
                Directory.Delete(targetDirectory, true);
            }
            Directory.CreateDirectory(targetDirectory);
            ExtractZipWithOverwrite(Path.Combine(currentAppDirectory, $"{appName.ToLower()}_latest.zip"), targetDirectory);
            //ZipFile.ExtractToDirectory(Path.Combine(currentAppDirectory, $"{appName.ToLower()}_latest.zip"), targetDirectory);
            File.Delete(Path.Combine(currentAppDirectory, $"{appName.ToLower()}_latest.zip"));

            downloadForm.UpdateDownload(100, "Download Complete!");
            LauncherClient.SetAppConfig($"{appName}Version", releaseVersion);
            return targetDirectory;
        }

        private static void BaseDownloadApp(frmDownload downloadForm, string appName, string project, string expectedFile, Func<string, bool> configOperation)
        {
            // Download the app
            string targetDirectory = BaseUpdateApp(downloadForm, appName, project, expectedFile);
            downloadForm.UpdateDownload(80, "Applying base Settings...");
            // Then apply base settings
            configOperation(targetDirectory);
            LauncherClient.SetAppConfig($"{appName}Path", targetDirectory);

            downloadForm.UpdateDownload(100, "Download Complete!");
        }

        private static DownloadData FetchLatest(string project, string expectedFile, string appName)
        {
            // Bizhawk: TASEmulators/BizHawk
            // LiveSplit: LiveSplit/LiveSplit
            // RandoTools: TalicZealot/SotnRandoTools
            string apiUrl = $"{GetAPIUrl()}/latest/{project}";
            string downloadUrl = "";
            string releaseVersion = "";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    // Parse jsonString to get the latest release information
                    // For simplicity, let's assume it's JSON and deserialize it
                    dynamic release = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
                    releaseVersion = release.name;                    
                    
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
            return new DownloadData(downloadUrl, releaseVersion);
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

        public static void ExtractZipWithOverwrite(string zipFilePath, string extractPath)
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
                        string entryDirectory = Path.GetDirectoryName(entryPath);
                        if (!Directory.Exists(entryDirectory))
                        {
                            Directory.CreateDirectory(entryDirectory);
                        }
                        // Delete the existing file if it exists
                        if (File.Exists(entryPath))
                        {
                            File.Delete(entryPath);
                        }

                        // Extract the entry
                        entry.ExtractToFile(entryPath, true);
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

        public async static Task InitialSetupDone()
        {
            // Install the Preset Files
            DialogResult resultPres = DialogResult.Yes;
            if (LauncherClient.GetConfigValue("ImportedUser") != null)
            {
                resultPres = MessageBox.Show("This installation includes a few optional updates to RandoTools presets. Do you want to install them?", "Imported User Update Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            if (resultPres == DialogResult.Yes) await DownloadPresets();

            LauncherClient.SetAppConfig("InitialSetupCheck", "Done");
            LauncherClient.SetAppConfig("LauncherVersion", UpdateHandler.GetCurrentVersion().ToString());
            MessageBox.Show("Setup Successful! You can now use the Randomizer Launcher.", "Setup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private static void SetLastBrowsed(string path)
        {
            try
            {
                string pathBrowsed = Path.GetDirectoryName(path);
                SetAppConfig("LastPathBrowsed", pathBrowsed);
            }catch(Exception)
            {
                return;
            }            
        }
        #endregion
    }
}
