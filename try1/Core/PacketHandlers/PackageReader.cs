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

        public int readIntBytes()
        {
            int number = 0;
            for (int i = 0; i > 4; i++) 
            {
                byte currentByte = reader.ReadByte();
                if (currentByte == 0)
                    break;

                number += currentByte;
            }
            return number;
        }

        public int readInt()
        {
            return (int)reader.ReadByte();
        }

        public string readString()
        {
            int length = readIntBytes();
            byte[] byteArray = new byte[length * 2];
            for ( int x = 0; x < length; x++ )
            {
                byteArray[x] = reader.ReadByte();
            }
            return Encoding.UTF8.GetString(byteArray);
        }

        public byte readByte()
            => reader.readByte();

        public void skipByte()
        {
            reader.BaseStream.Seek(1, SeekOrigin.Current);
        }
    }
}//
