using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.PacketHandlers;

namespace ChatChimpClient.Core.Networking.Packets
{
    public class LoginResult : BasePacket
    {
        private string response { get; set; }
        public LoginResult(byte[] data) : base(data)
        {
            int result = readByte();
            if (result > 0)
            {
                Console.WriteLine("Login has failed");
                return;
            }
            response = readString();
            Console.WriteLine(response);
        }
    }
}