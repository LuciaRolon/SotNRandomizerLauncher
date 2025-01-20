using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    internal static class Randomizer
    {
        public static async Task StartRandomization(
                Action<int> progressBarUpdate,
                Action<string> updateSeed,
                Action<string> updateEquipment,
                RandomizerOptions options,
                CancellationToken randomizerCancellation,
                Action<bool> finishRandomize
            )
        {
            string suggestedFileName = "";
            if (options.Seed == "" || options.Seed == "(Optional)")
            {
                options.Seed = GenerateSeedName();                
            }
            suggestedFileName = $"{options.Preset}-{options.Seed}";
            if (options.AreaRando) suggestedFileName += "-AR";


            options.PpfFilePath = LauncherClient.InitiateStoreFile("Seed Preset File", suggestedFileName, "ppf");
            if (options.PpfFilePath == "") return; 
            await Task.Run(() => RandomizeSeedAsync(progressBarUpdate, updateSeed, updateEquipment, options, randomizerCancellation, finishRandomize));
        }

        public static string GenerateSeedName()
        {
            List<string> adjectives;
            List<string> nouns;

            int month = DateTime.Now.Month;            

            switch (month)
            {
                case 10:
                    adjectives = Constants.adjectivesHalloween;
                    nouns = Constants.nounsHalloween; 
                    break;
                case 12:
                    adjectives = Constants.adjectivesHolidays;
                    nouns = Constants.nounsNormal;
                    break;
                default:
                    adjectives = Constants.adjectivesNormal;
                    nouns = Constants.nounsNormal;
                    break;
               
            }
            

            Random random = new Random();
            string adjective = adjectives[random.Next(adjectives.Count)];
            string noun = nouns[random.Next(nouns.Count)];
            int number = random.Next(1000);

            if (number % 100 == 69)
            {
                return adjective + noun + "69Nice";
            }

            return adjective + noun + number.ToString();
        }

        public static void RandomizeSeed(
                Action<int> progressBarUpdate,
                Action<string> updateSeed,
                Action<string> updateEquipment,
                RandomizerOptions options
            )
        {
            progressBarUpdate(10);
            string args = options.GenerateArguments();
            progressBarUpdate(20);
            string randoFolder = Path.Combine(LauncherClient.GetConfigValue("RandomizerPath"), "Randomizer");
            string randoPath = Path.Combine(randoFolder, "randomizer.exe");
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = randoPath,
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = randoFolder
            };


            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                progressBarUpdate(30);

                // Create a cancellation token source to signal the progress update loop to stop
                // This will make the progress bar slowly raise until it finishes generating
                CancellationTokenSource cts = new CancellationTokenSource();
                Task progressTask = UpdateProgressBar(progressBarUpdate, 30, 80, cts.Token);

                // Read the output (if needed)
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();
                cts.Cancel();  // Cancel the progress update loop
                progressBarUpdate(80);
                if (options.BHSeed) RandomizeBHSeed(options);

                // Area randomization should always be the last step of randomization
                if (options.AreaRando) RunAreaRandomization(options);
                updateSeed($"Seed: {options.Seed}");
                if (options.ShowEquipment)
                {
                    string[] outputLines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    string equipment = "";
                    bool foundStartingEquipment = false;
                    for (int i = 0; i < outputLines.Length; i++)
                    {
                        // This reads the CLI from the point where it starts listing the equipment
                        if (outputLines[i].ToLower().Contains("starting equipment".ToLower()))  
                        {
                            foundStartingEquipment = true;
                        }

                        if (foundStartingEquipment)
                        {
                            equipment += $"{outputLines[i]}\n";
                        }
                    }
                    updateEquipment(equipment);
                }
                else
                {
                    updateEquipment("Starting Equipment: Equipment hidden.");
                }
                if(error == "" || error == null)
                {
                    MessageBox.Show("Seed generated successfully!", "Randomization Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Console.WriteLine(error);
                    MessageBox.Show("There was an error during randomization. Please, try again.", "Randomization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }
            progressBarUpdate(100);            
        }

        public static async Task RandomizeSeedAsync(
            Action<int> progressBarUpdate,
            Action<string> updateSeed,
            Action<string> updateEquipment,
            RandomizerOptions options,
            CancellationToken randomizerCancellation,
            Action<bool> finishRandomize)
        {
            progressBarUpdate(10);
            string args = options.GenerateArguments();
            progressBarUpdate(20);
            string randoFolder = Path.Combine(LauncherClient.GetConfigValue("RandomizerPath"), "Randomizer");
            string randoPath = Path.Combine(randoFolder, "randomizer.exe");
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = randoPath,
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = randoFolder
            };
            
            progressBarUpdate(30);
            // Create a cancellation token source to signal the progress update loop to stop
            // This will make the progress bar slowly raise until it finishes generating
            CancellationTokenSource cts = new CancellationTokenSource();
            Task progressTask = UpdateProgressBar(progressBarUpdate, 30, 80, cts.Token);
            string output = "";
            string error = "";
            try
            {
                Dictionary<string, string> result = await RunProcessAsync(startInfo, randomizerCancellation);
                output = result["output"];
                error = result["error"];
                cts.Cancel();  // Cancel the progress update loop
                progressBarUpdate(80);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            if (randomizerCancellation.IsCancellationRequested) return;
            if (options.BHSeed) RandomizeBHSeed(options);

            // Area randomization should always be the last step of randomization
            if (randomizerCancellation.IsCancellationRequested) return;
            if (options.AreaRando) RunAreaRandomization(options);
            updateSeed($"Seed: {options.Seed}");
            if (options.ShowEquipment)
            {
                string[] outputLines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                string equipment = "";
                bool foundStartingEquipment = false;
                for (int i = 0; i < outputLines.Length; i++)
                {
                    // This reads the CLI from the point where it starts listing the equipment
                    if (outputLines[i].ToLower().Contains("starting equipment".ToLower()))
                    {
                        foundStartingEquipment = true;
                    }

                    if (foundStartingEquipment)
                    {
                        equipment += $"{outputLines[i]}\n";
                    }
                }
                updateEquipment(equipment);
            }
            else
            {
                updateEquipment("Starting Equipment: Equipment hidden.");
            }

            bool randomizeSuccess = false;
            if (string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Seed generated successfully!", "Randomization Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                randomizeSuccess = true;
            }
            else
            {
                MessageBox.Show("There was an error during randomization. Please try again.", "Randomization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new Logger().LogError("Error after Randomization", error, args);
            }
            progressBarUpdate(100);
            finishRandomize(randomizeSuccess);
        }

        static async Task<Dictionary<string, string>> RunProcessAsync(ProcessStartInfo startInfo, CancellationToken cancellationToken)
        {
            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();

                // Read the output asynchronously and handle cancellation
                var outputTask = process.StandardOutput.ReadToEndAsync();
                var errorTask = process.StandardError.ReadToEndAsync();

                // Create a TaskCompletionSource to signal process completion
                TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
                process.Exited += (s, e) => tcs.TrySetResult(null);
                process.EnableRaisingEvents = true;

                using (cancellationToken.Register(() => tcs.TrySetCanceled()))
                {
                    try
                    {
                        await Task.WhenAny(tcs.Task, Task.Delay(Timeout.Infinite, cancellationToken));
                        if (cancellationToken.IsCancellationRequested)
                        {
                            try
                            {
                                process.Kill();
                            }
                            catch (InvalidOperationException) { } // Process already exited
                            throw new OperationCanceledException(cancellationToken);
                        }
                        await tcs.Task; // Ensure process has exited
                    }
                    catch (TaskCanceledException)
                    {
                        if (!process.HasExited)
                        {
                            try
                            {
                                process.Kill();
                            }
                            catch (InvalidOperationException) { } // Process already exited
                        }
                        throw new OperationCanceledException(cancellationToken);
                    }
                }

                string output = await outputTask;
                string error = await errorTask;
                Dictionary<string, string> resultDict = new Dictionary<string, string>();
                resultDict.Add("output", output);
                resultDict.Add("error", error);
                return resultDict;
            }
        }

        static void RandomizeBHSeed(RandomizerOptions options)
        {
            string randoFolder = Path.Combine(LauncherClient.GetConfigValue("RandomizerPath"), "Randomizer");
            string psxOrg = Path.Combine(randoFolder, "SotN_PSX.org");
            string bhBinFile = Path.Combine(randoFolder, "bhseed.bin");  // See RandomizerOptions.GenerateArguments
            string bhSeedFile = Path.Combine(randoFolder, "bhseed.PPF");
            try
            {
                // First, we get the SotN_PSX.org file required by the BH tool              
                File.Copy(LauncherClient.GetConfigValue("Track1Path"), psxOrg, true);
                // Generate the BH Tool arguments.                
                string input = "-input";
                if (options.Preset == "bountyhuntertc") input = "-tconf";
                if (options.Preset == "hitman") input = "-hitmn";
                string arguments = $"{input} \"{bhBinFile}\"";
                // Call the BH tool
                string bhToolPath = Path.Combine(randoFolder, "BountyHunter.exe");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = bhToolPath,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = randoFolder
                };
                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    process.WaitForExit();
                }
                // Now that the PPF is generated, copy it to the target path                
                File.Copy(bhSeedFile, options.PpfFilePath, true);
            }
            finally
            {
                // Cleanup the temporary files
                DeleteIfExists(psxOrg);
                DeleteIfExists(bhBinFile);
                DeleteIfExists(bhSeedFile);
            }         
            
        }

        static void DeleteIfExists(string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }

        static void RunAreaRandomization(RandomizerOptions options)
        {
            string areaRandoPath = LauncherClient.GetConfigValue("AreaRandoPath");
            string psxOrg = Path.Combine(areaRandoPath, "SotN_PSX.org");
            string areaRandoSeedFile = Path.Combine(areaRandoPath, "arearando.PPF");
            string newBinPath = Path.Combine(areaRandoPath, "arearando.bin");
            try
            {
                // First, we need a copy of the track 1 bin patched with the generated PPF  
                LauncherClient.PatchBinCopy(options.PpfFilePath, newBinPath);
                // Similarly to BH Tool, we need a SotN_PSX.org file for PPF generation in the AreaRando folder                
                File.Copy(LauncherClient.GetConfigValue("Track1Path"), psxOrg, true);
                // After the game is patched, we can use the patched version to apply Area Randomization to it.
                string arguments = options.AreaRandoOptions.GenerateArguments(newBinPath);
                string areaRandoToolPath = Path.Combine(areaRandoPath, "SOTN_AR.exe");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = areaRandoToolPath,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = areaRandoPath
                };
                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    process.WaitForExit();
                }
                // Now that the PPF is generated, copy it to the target path                
                File.Copy(areaRandoSeedFile, options.PpfFilePath, true);
            }
            finally
            {
                // Cleanup the temporary files
                DeleteIfExists(psxOrg);
                DeleteIfExists(areaRandoSeedFile);
                DeleteIfExists(newBinPath);
            }                        
        }

        private static async Task UpdateProgressBar(Action<int> progressBarUpdate, int startValue, int endValue, CancellationToken cancellationToken)
        {
            int currentValue = startValue;
            int increment = 1;  // Increment value for each step
            int delay = 2000;   // Delay in milliseconds (2 seconds)

            while (currentValue < endValue && !cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(delay, cancellationToken);
                currentValue += increment;
                progressBarUpdate(currentValue);
            }
        }

        
    }
}
