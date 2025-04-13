using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotNRandomizerLauncher
{
    public enum AlucardPalettes
    {
        Default,
        BloodyTears,
        BlueDanube,
        SwampThing,
        WhiteKnight,
        RoyalPurple,
        PinkPassion,
        ShadowPrince        
    }

    public enum AlucardLiner
    {
        GoldTrim,
        SilverTrim,
        BronzeTrim,
        OnyxTrim,
        CoralTrim
    }
    public static class ModdingClient
    {
        private static List<ushort> WritesFromPalette(AlucardPalettes palette)
        {
            List<ushort> writes = null;
            switch (palette)
            {
                case AlucardPalettes.BloodyTears:
                    writes = new List<ushort> { 0x8404, 0x8c28, 0x8c4c, 0xa552, 0xb9f3, 0xcad8, 0xf39c };
                    break;
                case AlucardPalettes.BlueDanube:
                    writes = new List<ushort> { 0x9021, 0xa043, 0xb8a6, 0xc529, 0xcded, 0xcef5, 0xf39c };
                    break;
                case AlucardPalettes.SwampThing:
                    writes = new List<ushort> { 0x8042, 0x8082, 0x80c6, 0x8d2f, 0xa9d1, 0xc6d5, 0xe39b };
                    break;
                case AlucardPalettes.WhiteKnight:
                    writes = new List<ushort> { 0x9063, 0x94a5, 0xa12a, 0xb9f0, 0xd674, 0xeb5b, 0xf39c };
                    break;
                case AlucardPalettes.RoyalPurple:
                    writes = new List<ushort> { 0x8c02, 0x9c04, 0xac88, 0xbd0a, 0xcdad, 0xc655, 0xcf18 };
                    break;
                case AlucardPalettes.PinkPassion:
                    writes = new List<ushort> { 0x9024, 0x9867, 0xa8ac, 0xbd31, 0xcdf5, 0xeabb, 0xfb1d };
                    break;
                case AlucardPalettes.ShadowPrince:
                    writes = new List<ushort> { 0x8000, 0x8c42, 0x98a5, 0xa0e9, 0xa96d, 0xb9f1, 0xc655 };
                    break;
                case AlucardPalettes.Default:
                    writes = new List<ushort> { 0x8000, 0x8421, 0x98a5, 0xa94a, 0xbe2e, 0xc2f7, 0xf39c };
                    break;
            }
            return writes;
        }

        private static List<ushort> WritesFromLiner(AlucardLiner liner)
        {
            List<ushort> writes = null;
            switch (liner)
            {
                case AlucardLiner.GoldTrim:
                    writes = new List<ushort> { 0x84ab, 0x8d2f, 0x91d6, 0x929b };
                    break;
                case AlucardLiner.BronzeTrim:
                    writes = new List<ushort> { 0x8465, 0x88a8, 0x88ec, 0x9151 };
                    break;
                case AlucardLiner.SilverTrim:
                    writes = new List<ushort> { 0x94a6, 0xa54a, 0xb9ef, 0xc693 };
                    break;
                case AlucardLiner.OnyxTrim:
                    writes = new List<ushort> { 0x8c43, 0x98a5, 0x9cc8, 0xa54c };
                    break;
                case AlucardLiner.CoralTrim:
                    writes = new List<ushort> { 0xa8ac, 0xad0f, 0xadb3, 0xbe16 };
                    break;
            }
            return writes;
        }
        public static void InstallCustomSkin(AlucardPalettes palette, AlucardLiner liner)
        {
            List<ushort> paletteWrites = WritesFromPalette(palette);
            List<ushort> linerWrites = WritesFromLiner(liner);
            long offset = 0x0;
            // Retrieve the file, setup the offsets, and do the writes using BinaryEditor.cs
            string track1Path = LauncherClient.GetConfigValue("Track1Path");
            string track1FileName = Path.GetFileName(track1Path);
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string randomPath = Path.Combine(currentAppDirectory, "files", "randomized");
            track1Path = Path.Combine(randomPath, track1FileName);
            var fs = new FileStream(track1Path, FileMode.Open, FileAccess.ReadWrite);
            BinaryEditor editor = new BinaryEditor(fs);

            // Apply Palette Colors
            if (paletteWrites != null)
            {
                // Cloth Colors
                offset = 0xEF952;
                for (int i = 0; i < 5; i++) {
                    int idx = i + 2;
                    offset = editor.WriteShort(offset, paletteWrites[idx]);
                }
                // Darkest Color
                offset = 0xEF93E;
                offset = editor.WriteShort(offset, paletteWrites[1]);
            }

            // Apply Liner Colors
            if (linerWrites != null)
            {
                offset = 0xEF940;
                for (int i = 0; i < 4; i++)
                {
                    offset = editor.WriteShort(offset, linerWrites[i]);
                }
            }
            fs.Close();
        }
    }
}
