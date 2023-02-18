using ChatChimpClient.Core.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.Networking;

namespace ChatChimpClient.Core.PacketHandlers
{
    public class PackageWriter
    {
        BinaryWriter writer { get; set; }
        public PackageWriter(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            writer = new BinaryWriter(ms);
        }

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
            byte[] toWrite = BitConverter.GetBytes(number);
            for ( int x = 0; x < 4; x++ )
            {
                writer.Write(toWrite[x]);
            }
        }

        public void writeString(string letters)
        {
            byte[] toWrite = Encoding.UTF8.GetBytes(letters);
            for ( int x = 0; x < 4; x++ )
            {
                writer.Write(toWrite[x]);
            }
        }
    }
}