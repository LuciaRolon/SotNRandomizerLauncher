using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotNRandomizerLauncher
{
    public class BinaryEditor
    {
        private Stream file;
        private Dictionary<long, WriteInfo> writes = new Dictionary<long, WriteInfo>();

        public BinaryEditor(Stream fileStream)
        {
            this.file = fileStream;
        }

        public long WriteShort(long address, ushort val)
        {
            CheckAddressRange(address);

            byte[] bytes = new byte[]
            {
            (byte)(val & 0xFF),
            (byte)((val >> 8) & 0xFF)
            };

            if (file != null)
            {
                if (file.CanSeek && file.CanWrite)
                {
                    file.Seek(address, SeekOrigin.Begin);
                    file.Write(bytes, 0, 2);
                }
                else
                {
                    throw new InvalidOperationException("Stream is not seekable or writable.");
                }
            }

            for (long i = address; i < address + 2; i++)
            {
                writes.Remove(i);
            }

            writes[address] = new WriteInfo
            {
                Length = 2,
                Value = (ushort)(val & 0xFFFF)
            };

            address += 2;

            // CD-ROM User Data check (2352 bytes per sector, user data range is first 2072 bytes)
            if ((address % 2352) > 2071)
            {
                address = ((address / 2352) * 2352) + 2376;
            }

            return address;
        }

        private void CheckAddressRange(long address)
        {
            if (address < 0xFFFF || address > 0xFFFFFFFF)
            {
                throw new ArgumentOutOfRangeException(nameof(address), $"Bad address: 0x{address:X}");
            }
        }

        private class WriteInfo
        {
            public int Length { get; set; }
            public ushort Value { get; set; }
        }
    }
}
