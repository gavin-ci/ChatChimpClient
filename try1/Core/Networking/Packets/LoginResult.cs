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
            int result = reader.readByte();
            if (result > 0)
            {
                Console.WriteLine("Login has failed");
                return;
            }
            response = reader.readString();
            Console.WriteLine(response);
        }
    }
}