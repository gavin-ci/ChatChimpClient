using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.PacketHandlers;

namespace ChatChimpClient.Core.Networking.Packets
{
    public class loginPacket
    {
        int usernameLength { get; set; }
        int passwordLength { get; set; }
        public loginPacket(PackageReader reader)
        {
            usernameLength = reader.readInt();
        }
    }
}