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

        public void writeInt(int number)
        {
            byte[] toWrite = BitConverter.GetBytes(number);
            for ( int x = 0; x < 4; x++ )
            {
                writer.Write(toWrite[x]);
            }
        }
    }
}