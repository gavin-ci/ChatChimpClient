using ChatChimpClient.Core.PacketHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Networking.Packets
{
    internal class Heartbeat
    {
        public Heartbeat() {
            Globals.packageHandler.createHeader(9, 5);
            Globals.packageHandler.writeByte((byte)Globals.client.getState());
        }
    }
}
