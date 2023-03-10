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
        public Heartbeat(PackageWriter writer) {
            writer.createHeader(9, 5);
            writer.writeByte((byte)Globals.client.getState());
        }
    }
}
