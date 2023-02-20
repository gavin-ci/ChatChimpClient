using ChatChimpClient.Core.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.Networking;

namespace ChatChimpClient.Core.PacketHandlers
{
    public class ProcessPacket {
        private byte[] data { get; set; }
        private int packetLength { get; set; }
        private int packetId { get; set; }
        private PackageReader reader { get; set; }

        void readHeader()
        {
            packetLength = reader.readInt();
            packetId = reader.readInt();
        }

        public ProcessPacket( Client client ) {
            data = client.getBuffer();
            reader = new PackageReader( data );
            readHeader();

            switch(packetId)
            {
                case 1:
                    initPacket initPacket = new initPacket(data);
                    if( !(initPacket.response > 0))
                    {
                        Console.WriteLine("connected to the server");
                    }
                    break;
                case 3:
                    LoginResult loginPacket = new LoginResult(data);
                    break;
            }
        }
    };
}
