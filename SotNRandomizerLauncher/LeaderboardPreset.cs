using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotNRandomizerLauncher
{
    internal class LeaderboardPreset
    {
        public string PresetID { get; set; }
        public string PresetName { get; set; }

        public override string ToString()
        {
            return this.PresetName;
        }
    }
}
