using ChatChimpClient.Core.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.Networking;

namespace ChatChimpClient.Core.PacketHandlers
{
    public class PackageCreator
    {
        byte[] data { get; set; }
        PackageWriter writer { get; set; }

        public void createHeader(byte packetLength, byte packetId)
        {
            writer.writeByte(packetLength);
            writer.writeByte(0);
            writer.writeByte(packetId);
            writer.writeByte(0);
        }

        public PackageCreator(int packetLength, int packetId, Client client)
        {
            data = client.getBuffer();
            writer = new PackageWriter(data);
            createHeader((byte)packetLength, (byte)packetId);
            switch (packetId)
            {
                case 2:
                    loginPacket packet = new loginPacket(writer);
                    break;
            }
        }
    }
}