using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.PacketHandlers;

namespace ChatChimpClient.Core.Networking.Packets
{
    public class LoginResult
    {
        private string response { get; set; }
        public LoginResult()
        {
            int result = Globals.packageHandler.readByte();
            if (result > 0)
            {
                Console.WriteLine("Login has failed");
                return;
            }
            response = Globals.packageHandler.readString();
            Console.WriteLine(response);
        }
    }
}