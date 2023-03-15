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
        public LoginPacket(string username, string password)
        {
            Globals.packageHandler.createHeader(18 + username.Length + password.Length, 2);
            Globals.packageHandler.writeString(username);
            Globals.packageHandler.writeString(password);
        }
    }
}