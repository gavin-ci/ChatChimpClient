using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.PacketHandlers;

namespace ChatChimpClient.Core.Networking.Packets
{
    public class loginResult
    {
        string responce { get; set; }
        public LoginResult(PackageReader reader)
        {
            byte result = reader.readByte();
            if (!result)
            {
                Console.WriteLine("Login has failed");
                return;
            }
            responce = reader.readString();
            Console.WriteLine(responce);
        }
    }
}