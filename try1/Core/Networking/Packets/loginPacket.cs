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
        public loginPacket(PackageWriter writer)
        {
            username = "Funny Monkey The 3rd";
            password = "i-L0v3-M0nK13s";

            writer.writeInt(username.Length);
            writer.writeString(username);
            writer.writeInt(password.Length);
            writer.writeString(password);
        }
    }
}