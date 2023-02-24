using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.PacketHandlers;

namespace ChatChimpClient.Core.Networking.Packets
{
    public class initPacket : BasePacket
    {
        public int response { get; set; }
        public initPacket(byte[] data) : base(data)
        {
            response = readInt();
        }
    }
}
