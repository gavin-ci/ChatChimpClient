using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.PacketHandlers
{
    public class PackageReader
    {
        private BinaryReader reader { get; set; }
        public PackageReader(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            reader = new BinaryReader(ms);
        }

        public int readInt()
        {
            return (int)reader.ReadByte();
        }

        public string readString(int length)
        {
            byte[] byteArray = new byte[length];
            for ( int x = 0; x < length; x++ )
            {
                byteArray[x] = reader.ReadByte();
            }
            return Encoding.UTF8.GetString(byteArray);
        }

        public void skipByte()
        {
            reader.BaseStream.Seek(1, SeekOrigin.Current);
        }
    }
}//
