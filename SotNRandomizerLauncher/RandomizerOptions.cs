using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotNRandomizerLauncher
{
    enum MapColor
    {
        Blue,
        Crimson,
        Brown,
        Green,
        Gray,
        Purple,
        Pink,
        Default
    }
    internal class RandomizerOptions
    {
        public bool TournamentMode { get; set; }
        public bool VanillaMusic { get; set; }
        public bool ShowEquipment { get; set; }
        public bool MagicMaxMode { get; set; }
        public bool AntiFreezeMode { get; set; }
        public bool MyPurseMode { get; set; }
        public bool ColorRando { get; set; }
        public string RelicExtension { get; set; }
        public string Preset { get; set; }
        public string PpfFilePath { get; set; }
        public string Seed { get; set; }
        public MapColor MapColor { get; set; }
        public int Complexity { get; set; }


        public string GenerateArguments()
        {
            string arguments = "";
            if (this.TournamentMode) arguments += "-t ";            
            if (this.MagicMaxMode) arguments += "-x ";            
            if (this.AntiFreezeMode) arguments += "-z ";
            if (this.ColorRando) arguments += "-l ";
            if (this.MyPurseMode) arguments += "-y ";
            if (this.Complexity > 0) arguments += $"-c {this.Complexity} ";
            char mapColor = MapColorToSetting(this.MapColor);
            if (mapColor != ' ') arguments += $"-m {mapColor} ";
            
            arguments += $"-p {this.Preset.ToLower()} -s {this.Seed} ";
            if (this.VanillaMusic || this.RelicExtension != "")
            {
                arguments += "--opt ";
                if (this.VanillaMusic) arguments += "~m";                
                if (this.RelicExtension != "") arguments += $"r:x:{RelicExtension.ToLower()}";                
            }
            arguments += $" -o \"{this.PpfFilePath}\"";
            if (this.ShowEquipment) arguments += " -vv ";
            
            return arguments;
        }

        public char MapColorToSetting(MapColor color)
        {
            switch (color)
            {
                case MapColor.Purple: return 'p';
                case MapColor.Pink: return 'k';
                case MapColor.Gray: return 'y';
                case MapColor.Green: return 'g';
                case MapColor.Crimson: return 'r';
                case MapColor.Brown: return 'b';
                case MapColor.Blue: return 'u';
            }
            return ' ';
        }
    }
}
