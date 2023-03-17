using ChatChimpClient.Core.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.Networking;

namespace ChatChimpClient.Core.PacketHandlers {
    public class ProcessPacket {
        private int packetLength { get; set; }
        private int packetId { get; set; }

        void readHeader() {
            packetLength = Globals.packageHandler.readInt();
            packetId = Globals.packageHandler.readInt();
        }

        public ProcessPacket() {
            readHeader();

            switch(packetId) {
                case (int)packetTypes.CONNECT:
                    initPacket initPacket = new initPacket();
                    if( !(initPacket.response > 0)) {
                        Console.WriteLine("connected to the server");
                        Globals.client.startTimer();
                    }
                    break;
                case (int)packetTypes.LOGIN_RESULT:
                    LoginResult loginPacket = new LoginResult();
                    break;
            }
        }
    };
}
