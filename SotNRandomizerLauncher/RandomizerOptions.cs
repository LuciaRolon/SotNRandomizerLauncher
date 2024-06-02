using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotNRandomizerLauncher
{
    internal class RandomizerOptions
    {
        public bool TournamentMode { get; set; }
        public bool VanillaMusic { get; set; }
        public bool ShowEquipment { get; set; }
        public bool MagicMaxMode { get; set; }
        public bool AntiFreezeMode { get; set; }
        public string RelicExtension { get; set; }
        public string Preset { get; set; }
        public string PpfFilePath { get; set; }
        public string Seed { get; set; }


        public string GenerateArguments()
        {
            string arguments = "";
            if (this.TournamentMode)
            {
                arguments += "-t ";
            }            
            if (this.MagicMaxMode)
            {
                arguments += "-x ";
            }
            if (this.AntiFreezeMode)
            {
                arguments += "-z ";
            }
            arguments += $"-p {this.Preset.ToLower()} -s {this.Seed} ";
            if (this.VanillaMusic || this.RelicExtension != "")
            {
                arguments += "--opt ";
                if (this.VanillaMusic)
                {
                    arguments += "~m";
                }
                if(this.RelicExtension != "")
                {
                    arguments += $"r:x:{RelicExtension.ToLower()}";
                }
            }
            arguments += $" -o {this.PpfFilePath}";
            if (this.ShowEquipment)
            {
                arguments += " -vv ";
            }
            return arguments;
        }
    }
}
