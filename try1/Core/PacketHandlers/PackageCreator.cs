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

        public void createHeader(int packetLength, int  packetId)
        {
            writer.writeInt(packetLength);
            writer.writeInt(packetId);
        }

        public PackageCreator(int packetLength, int packetId, Client client)
        {
            //data = client.getBuffer();
            writer = new PackageWriter();
            createHeader((byte)packetLength, (byte)packetId);
            switch (packetId)
            {
                case (int)packetTypes.LOGIN:
                    LoginPacket packet = new LoginPacket(writer);
                    break;
            }
        }
    }
}