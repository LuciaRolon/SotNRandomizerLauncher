using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Net.Http;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LauncherUpdater
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

    internal static class LauncherUpdater
    {
        public static string GetAPIUrl()
        {            
            return "http://35.208.162.255:8080";
        }        

        public static void UpdateLauncherApp(object obj)
        {
            frmDownload downloadForm = (frmDownload)obj;
            BaseUpdateApp(downloadForm, "Launcher", "LuciaRolon/SotNRandomizerLauncher", "SotNRandomizerLauncher-portable");            
        }

        private static string BaseUpdateApp(frmDownload downloadForm, string appName, string project, string expectedFile)
        {
            downloadForm.UpdateDownload(0, $"Fetching latest {appName} version...");
            // Get the download URL of the latest Launcher release
            DownloadData downloadData = FetchLatest(project, expectedFile, appName);
            string downloadUrl = downloadData.downloadUrl;
            Console.WriteLine(downloadUrl);

            // Download Launcher
            downloadForm.UpdateDownload(5, $"Downloading {appName}...");
            WebClient downloadClient = new WebClient();
            downloadClient.DownloadFile(new Uri(downloadUrl), $"{appName.ToLower()}_latest.zip");

            // Extract the app into the corresponding folder
            downloadForm.UpdateDownload(60, $"Installing {appName}...");
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string targetDirectory = currentAppDirectory;
            ExtractZipWithOverwrite(Path.Combine(currentAppDirectory, $"{appName.ToLower()}_latest.zip"), targetDirectory);
            File.Delete(Path.Combine(currentAppDirectory, $"{appName.ToLower()}_latest.zip"));

            downloadForm.UpdateDownload(100, "Download Complete!");
            return targetDirectory;
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
                        try
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
                        }catch(UnauthorizedAccessException)  // If it's trying to modify a locked file, just continue
                        {
                            continue;
                        }                        
                    }
                }
            }
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

                    foreach (var asset in release.assets)
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
    }
}
