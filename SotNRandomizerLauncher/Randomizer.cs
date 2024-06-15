using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
                RandomizerOptions options
            )
        {
            string suggestedFileName = "";
            if (options.Seed == "" || options.Seed == "(Optional)")
            {
                options.Seed = GenerateSeedName(options.Preset);
                suggestedFileName = options.Seed;
            }
            else
            {
                suggestedFileName = $"{options.Preset}-{options.Seed}";
            }


            options.PpfFilePath = LauncherClient.InitiateStoreFile("Seed Preset File", suggestedFileName, "ppf");
            await Task.Run(() => RandomizeSeed(progressBarUpdate, updateSeed, updateEquipment, options));
        }

        public static string GenerateSeedName(string preset)
        {
            Random random = new Random();
            char[] digits = new char[13];

            // Generate each digit and store in the char array
            for (int i = 0; i < 13; i++)
            {
                digits[i] = (char)('0' + random.Next(0, 10));
            }

            // Convert the char array to a string
            string seedNumber = new string(digits);
            return $"{preset}-{seedNumber}";
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
                if (options.BHSeed)
                {
                    RandomizeBHSeed(options);
                }

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
                    MessageBox.Show("There was an error during randomization. Please, try again.", "Randomization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }
            progressBarUpdate(100);
            
        }        

        static void RandomizeBHSeed(RandomizerOptions options)
        {
            // First, we get the SotN_PSX.org file required by the BH tool
            string randoFolder = Path.Combine(LauncherClient.GetConfigValue("RandomizerPath"), "Randomizer");
            string psxOrg = Path.Combine(randoFolder, "SotN_PSX.org");
            File.Copy(LauncherClient.GetConfigValue("Track1Path"), psxOrg, true);
            // Generate the BH Tool arguments.
            string bhBinFile = Path.Combine(randoFolder, "bhseed.bin");  // See RandomizerOptions.GenerateArguments
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
            string bhSeedFile = Path.Combine(randoFolder, "bhseed.PPF");
            File.Copy(bhSeedFile, options.PpfFilePath, true);
            // Cleanup the temporary files
            File.Delete(psxOrg);
            File.Delete(bhBinFile);
            File.Delete(bhSeedFile);
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
