using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.PacketHandlers
{
    public class PackageReader
    {
        private BinaryReader reader { get; set; }
        public PackageReader(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            reader = new BinaryReader(ms);
        }
    }
}//
