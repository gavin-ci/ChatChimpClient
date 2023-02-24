using ChatChimpClient.Core.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.Networking;

namespace ChatChimpClient.Core.PacketHandlers
{
    public class PackageWriter {
        BinaryWriter writer { get; set; }

        byte[] data { get; set; }
        public PackageWriter()
        {
            data = new byte[ Globals.client.getBuffer().Length ];
            MemoryStream ms = new MemoryStream(data);
            writer = new BinaryWriter(ms);
        }

        public void createHeader(int packetLength, int packetId) {
            writeInt(packetLength);
            writeInt(packetId);
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
            writer.Write7BitEncodedInt(number);
        }

        public void writeString(string letters)
        {
            int msgLen = Encoding.UTF8.GetBytes(letters).Length;
            writeInt(msgLen);
            writer.Write(letters);
        }

        public byte[] getData()
            => data;
    }
}