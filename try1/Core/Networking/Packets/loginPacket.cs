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
        string username { get; set; }
        string password { get; set; }
        public loginPacket(PackageReader reader)
        {
            username = reader.readString();
            password = reader.readString();
        }
    }
}