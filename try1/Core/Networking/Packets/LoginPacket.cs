using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.PacketHandlers;

namespace ChatChimpClient.Core.Networking.Packets
{
    public class LoginPacket : BasePacket
    {
        string username { get; set; }
        string password { get; set; }
        public LoginPacket(PackageWriter writer, string username, string password)
        {
            writer.createHeader(18 + username.Length + password.Length, 2);
            writer.writeString(username);
            writer.writeString(password);
        }
    }
}