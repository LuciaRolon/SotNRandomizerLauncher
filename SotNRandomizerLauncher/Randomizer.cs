using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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


                updateSeed($"Seed: {options.Seed}");
                if (options.ShowEquipment)
                {
                    string[] outputLines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    string equipment = "";
                    for (int i = 2; i < outputLines.Length; i++)
                    {
                        equipment += $"{outputLines[i]}\n";
                    }
                    updateEquipment(equipment);
                }
                else
                {
                    updateEquipment("Starting Equipment: Equipment hidden.");
                }
            }
            progressBarUpdate(100);
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
