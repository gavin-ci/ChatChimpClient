using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Networking.Packets
{
    public class BasePacket
    {
        BinaryReader reader { get; set; }
        BinaryWriter writer { get; set; }
        public BasePacket(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            reader = new BinaryReader(ms);
            writer = new BinaryWriter(ms);
        }

        // ---------------- WRITER FUNCTIONS ----------------

        public void writeByte(byte b)
            => writer.Write(b);

        public void writeUshort(ushort number)
        {
            byte[] toWrite = BitConverter.GetBytes(number);
            for ( int x = 0; x < 2; x++ )
            {
                writer.Write(toWrite[x]);
            }
        }

        public void writeInt(int number)
        {
            writer.Write7BitEncodedInt(number);
        }

        public void writeString(string letters)
        {
            int msgLen = Encoding.UTF8.GetBytes(letters).Length;
            writeInt(msgLen);
            writer.Write(letters);
        }

        // ------------ READING FUNCTIONS --------------

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

        public int readByte()
            => reader.BaseStream.ReadByte();

        public void skipByte()
        {
            reader.BaseStream.Seek(1, SeekOrigin.Current);
        }
    }
}