using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.PacketHandlers;

namespace ChatChimpClient.Core.Networking.Packets
{
    public class LoginPacket
    {
        string username { get; set; }
        string password { get; set; }
        public LoginPacket(PackageWriter writer)
        {
            username = "test";
            password = "123";

            writer.writeString(username);
            writer.writeString(password);
        }
    }
}