using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserClient;

namespace try1.Packets
{
    public class initPacket
    {
        public int response { get; set; }
        public initPacket(PackageReader reader)
        {
           response =  reader.readInt();
        }
    }
}
