using try1.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserClient;

namespace try1
{
    public class ProcessPacket {
        private byte[] data { get; set; }
        private int packetLength { get; set; }
        private int packetId { get; set; }
        private PackageReader reader { get; set; }

        void createHeader()
        {
            packetLength = reader.readInt();
            reader.skipByte();
            packetId = reader.readInt();
            reader.skipByte();
        }

        public ProcessPacket( Client client ) {
            data = client.getBuffer();
            reader = new PackageReader( data );
            createHeader();

            switch(packetId)
            {
                case 1:
                    initPacket packet = new initPacket(reader);
                    if( !(packet.response > 0))
                    {
                        Console.WriteLine("connected to the server");
                    }
                    break;
            }
        }
    };
}
