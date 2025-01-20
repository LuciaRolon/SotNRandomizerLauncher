using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        Black,
        Invisible,
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
        public bool BHSeed { get; set; }
        public bool AreaRando { get; set; }
        public AreaRandoOptions AreaRandoOptions { get; set; }
        public bool IWBMode { get; set; }
        public bool FastWarpMode { get; set; }
        public bool UnlockedMode { get; set; }
        public bool ExcludeSongs { get; set; }
        public bool IsCustom { get; set; }
        public bool EnemyStatRando { get; set; }
        public bool MisteryMode { get; set; }
        public bool ShopPrices { get; set; }
        public bool StartingZone { get; set; }
        public bool NoPrologue { get; set; }
        public CheckState ItemStats { get; set; }
        public CheckState ItemLocations { get; set; }
        public CheckState EnemyDrops { get; set; }
        public CheckState StartingEquipment { get; set; }
        public CheckState PrologueRewards { get; set; }
        public CheckState TurkeyMode { get; set; }
        public CheckState RelicLocations { get; set; }

        private string GetArgument(CheckState state, string checkedValue)
        {
            if(state == CheckState.Indeterminate) return "";
            return state == CheckState.Checked ? checkedValue : $"~{checkedValue}";
        }


        public string GenerateArguments()
        {
            string arguments = "";
            if (this.TournamentMode) arguments += "-t ";            
            if (this.MagicMaxMode) arguments += "-x ";            
            if (this.AntiFreezeMode) arguments += "-z ";
            if (this.ColorRando) arguments += "-l ";
            if (this.MyPurseMode) arguments += "-y ";
            if (this.IWBMode) arguments += "-b ";
            if (this.FastWarpMode) arguments += "-9 ";
            if (this.UnlockedMode) arguments += "-U ";
            if (this.MisteryMode) arguments += "-S ";
            if (this.EnemyStatRando) arguments += "-E ";
            if (this.ShopPrices) arguments += "--sh ";
            if (this.StartingZone) arguments += "--ori ";
            if (this.NoPrologue) arguments += "-R ";
            if (this.ExcludeSongs)
            {
                string excludeSongList = LauncherClient.GetConfigValue("ExcludedSongs");
                arguments += $"--eds {excludeSongList} ";
            }
            if (this.Complexity > 0) arguments += $"-c {this.Complexity} ";
            char mapColor = MapColorToSetting(this.MapColor);
            if (mapColor != ' ') arguments += $"-m {mapColor} ";

            if (this.IsCustom)
            {
                string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string customPresetsPath = Path.Combine(currentAppDirectory, "files", "customPresets");
                string presetPath = Path.Combine(customPresetsPath, $"{this.Preset}.json");
                arguments += $"-f \"{presetPath}\" ";
            }
            else
            {
                arguments += $"-p {this.Preset.ToLower()} ";
            }
            arguments += $"-s {this.Seed} ";
            var states = new[] { this.EnemyDrops, this.ItemLocations, this.ItemStats, this.StartingEquipment, this.PrologueRewards, this.TurkeyMode, this.RelicLocations };
            if (this.VanillaMusic || this.RelicExtension != "" || states.Any(state => state != CheckState.Indeterminate))
            {
                arguments += "--opt ";
                if (this.Preset == "bingo")
                {
                    arguments += "~r";                    
                }
                else
                {
                    if (this.VanillaMusic) arguments += "~m";                  
                }
                arguments += GetArgument(this.EnemyDrops, "d");
                arguments += GetArgument(this.ItemLocations, "i");
                arguments += GetArgument(this.ItemStats, "s");
                arguments += GetArgument(this.StartingEquipment, "e");
                arguments += GetArgument(this.PrologueRewards, "b");
                arguments += GetArgument(this.TurkeyMode, "k");
                if (this.RelicExtension != "")
                {
                    arguments += $"r:x:{RelicExtension.ToLower()}";
                }
                else if (this.RelicLocations == CheckState.Unchecked)
                {
                    arguments += "~r";
                }
            }
            if (this.BHSeed)
            {
                string track1Path = LauncherClient.GetConfigValue("Track1Path");
                arguments += $" --in-bin \"{track1Path}\" -o .\\bhseed.bin";
            }
            else
            {
                arguments += $" -o \"{this.PpfFilePath}\"";
            }
            
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
                case MapColor.Brown: return 'n';
                case MapColor.Blue: return 'u';
                case MapColor.Black: return 'b';
                case MapColor.Invisible: return 'i';
            }
            return ' ';
        }
    }
}
