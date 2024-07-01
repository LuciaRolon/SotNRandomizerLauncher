using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotNRandomizerLauncher
{
    public class AreaRandoOptions
    {
        public bool RandomStartingPoint { get; set; }
        public bool SPIncludeSecondCastle { get; set; }
        public bool BlockCavernsOnFirstVisit { get; set; }
        public bool DisableFlash { get; set; }
        public string StartingRelic { get; set; }

        public AreaRandoOptions()  // Default settings
        {
            this.RandomStartingPoint = false;
            this.SPIncludeSecondCastle = false;
            this.BlockCavernsOnFirstVisit = false;
            this.DisableFlash = false;
            this.StartingRelic = "leapstone";
        }

        public string GenerateArguments(string binFile)
        {
            // During randomization, generate a copy of the bin through the Randomizer
            // Then use that BIN here and delete it after the PPF has been created.
            this.StartingRelic = this.StartingRelic.Replace(" ", "");
            string arguments = $"-input \"{binFile}\" -output \"{binFile}\" -arearando -arearelic \"{this.StartingRelic}\"";

            if (this.BlockCavernsOnFirstVisit) arguments += " -areablockcaverns";
            if (this.RandomStartingPoint)
            {
                arguments += (this.SPIncludeSecondCastle) ? " -sprando2nd" : "-sprando";
            }
            if (this.DisableFlash) arguments += "-flashdisable";
            arguments += " -createppf -executepatch -terminate";
            return arguments;
        }
    }
}
