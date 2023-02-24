using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Networking.Packets
{
    public class BasePacket
    {
        protected BinaryReader reader { get; set; }
        protected BinaryWriter writer { get; set; }
        public BasePacket(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            reader = new BinaryReader(ms);
        }

        public BasePacket()
        {
            
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
            return reader.Read7BitEncodedInt();
        }

        public string readString()
        {
            int length = readInt();
            return Encoding.UTF8.GetString( reader.ReadBytes(length) );
        }

        public int readByte()
            => reader.BaseStream.ReadByte();

        public void skipByte()
        {
            reader.BaseStream.Seek(1, SeekOrigin.Current);
        }
    }
}
