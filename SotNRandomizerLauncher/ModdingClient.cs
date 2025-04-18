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
        ShadowPrince,
        Disabled
    }

    public enum AlucardLiner
    {
        GoldTrim,
        SilverTrim,
        BronzeTrim,
        OnyxTrim,
        CoralTrim,
        Disabled
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

        private static List<ushort> WolfWritesFromPalette(AlucardPalettes palette)
        {
            List<ushort> writes = null;
            switch (palette)
            {
                case AlucardPalettes.BloodyTears:
                    writes = new List<ushort> { 0x8005, 0x802a, 0x8cad, 0xa4f6, 0x810d, 0xbdf8, 0x81f9, 0xa31f, 0x82df, 0x8003, 0x8023, 0x8447, 0x94ab, 0xa112 };
                    break;
                case AlucardPalettes.BlueDanube:
                    writes = new List<ushort> { 0xa465, 0xb884, 0xc8e6, 0xd58b, 0x8d21, 0xe690, 0x9a42, 0xb6e8, 0xa360, 0x9802, 0x9423, 0xa863, 0xb908, 0xc147 };
                    break;
                case AlucardPalettes.SwampThing:
                    writes = new List<ushort> { 0x8063, 0x80c7, 0x8509, 0x954e, 0xa42a, 0xadd4, 0xc454, 0xd55a, 0xe85a, 0x8021, 0x8042, 0x8064, 0x8886, 0xa4eb };
                    break;
                case AlucardPalettes.WhiteKnight:
                    writes = new List<ushort> { 0x8c64, 0xa0e8, 0xad6b, 0xde52, 0xb4e0, 0xfb9a, 0xe5e0, 0xfe27, 0xfea0, 0x8422, 0x8c64, 0x9484, 0xb129, 0xd1ef };
                    break;
                case AlucardPalettes.RoyalPurple:
                    writes = new List<ushort> { 0xa465, 0xb447, 0xb88b, 0xd94f, 0x98c7, 0xd9d8, 0xad8e, 0xca75, 0xbe36, 0x9802, 0x9423, 0xa445, 0xa067, 0xb0cd };
                    break;
                case AlucardPalettes.PinkPassion:
                    writes = new List<ushort> { 0x9826, 0xa46c, 0xb8f2, 0xe1d8, 0x8422, 0xfaba, 0x8844, 0x9086, 0x90cb, 0x8c03, 0x8c24, 0x9c69, 0xb50d, 0xcd2f };
                    break;
                case AlucardPalettes.ShadowPrince:
                    writes = new List<ushort> { 0x8822, 0x8c43, 0x98a5, 0xa0e9, 0x808d, 0xa96d, 0x80f9, 0x8d9e, 0x813f, 0x8421, 0x8822, 0x8822, 0x9063, 0x9484 };
                    break;
                case AlucardPalettes.Default:
                    writes = new List<ushort> { 0xa465, 0xbc88, 0xc8ec, 0xe5cf, 0x800d, 0xff35, 0x8019, 0xa17f, 0x801f, 0x9802, 0x9423, 0xa866, 0xb908, 0xd1a9 };
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

        private static List<ushort> WolfWritesFromLiner(AlucardLiner liner)
        {
            List<ushort> writes = null;
            switch (liner)
            {
                case AlucardLiner.GoldTrim:
                    writes = new List<ushort> { 0x9db5, 0xbebd, 0xff9a, 0x8888, 0x98f0, 0x90ec, 0xa990, 0xa9f6, 0x8023, 0x8049 };
                    break;
                case AlucardLiner.BronzeTrim:
                    writes = new List<ushort> { 0x94eb, 0xa56e, 0xba14, 0x8445, 0x9089, 0x8c66, 0x94a8, 0xa0eb, 0x8023, 0x8445 };
                    break;
                case AlucardLiner.SilverTrim:
                    writes = new List<ushort> { 0xc1cf, 0xded6, 0xff9a, 0x98a5, 0xb14b, 0xa509, 0xb9ce, 0xc611, 0x8421, 0x98a5 };
                    break;
                case AlucardLiner.OnyxTrim:
                    writes = new List<ushort> { 0xa52c, 0xa98a, 0x9cc7, 0x8c44, 0x98a8, 0x9486, 0x9ce7, 0xa509, 0x8001, 0x8c44 };
                    break;
                case AlucardLiner.CoralTrim:
                    writes = new List<ushort> { 0xbdf9, 0xce7d, 0xdf7c, 0x948a, 0xb553, 0xa10f, 0xbdd3, 0xbdf8, 0x8403, 0x904b };
                    break;
            }
            return writes;
        }

        public static void InstallCustomSkin(AlucardPalettes palette, AlucardLiner liner)
        {
            if(palette == AlucardPalettes.Disabled && liner == AlucardLiner.Disabled) return;
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
            int i = 0;
            // Apply Palette Colors
            if (paletteWrites != null)
            {
                List<ushort> wolfPaletteWrites = WolfWritesFromPalette(palette);
                // Cloth Colors
                offset = 0xEF952;
                for (i = 0; i < 5; i++) {
                    int idx = i + 2;
                    offset = editor.WriteShort(offset, paletteWrites[idx]);
                }
                // Darkest Color
                offset = 0xEF93E;
                offset = editor.WriteShort(offset, paletteWrites[1]);

                // Wolf Colors
                offset = 0xEF9C0;
                for (i = 0; i < 4; i++)
                {
                    offset = editor.WriteShort(offset, wolfPaletteWrites[i]);
                }
                offset += 0x0a;
                for (i = 4; i < 9; i++)
                {
                    offset = editor.WriteShort(offset, wolfPaletteWrites[i]);
                }
                offset += 0x04;
                for (i = 9; i < 13; i++)
                {
                    offset = editor.WriteShort(offset, wolfPaletteWrites[i]);
                }
                offset += 0x0c;
                offset = editor.WriteShort(offset, wolfPaletteWrites[13]);
            }

            // Apply Liner Colors
            if (linerWrites != null)
            {
                List<ushort> wolfLinerWrites = WolfWritesFromLiner(liner);
                offset = 0xEF940;
                for (i = 0; i < 4; i++)
                {
                    offset = editor.WriteShort(offset, linerWrites[i]);
                }
                offset = 0xEF9C8;
                for (i = 0; i < 5; i++)
                {
                    offset = editor.WriteShort(offset, wolfLinerWrites[i]);
                }
                offset += 0x20;
                for (i = 5; i < 10; i++)
                {
                    offset = editor.WriteShort(offset, wolfLinerWrites[i]);
                }
            }
            fs.Close();
        }
    }
}
