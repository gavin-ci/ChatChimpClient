using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Networking.Packets
{
    enum packetTypes { 
        CONNECT = 1,
        LOGIN = 2,
        LOGIN_RESULT = 3
    }

    enum packetSizes {
        CONNECT = 500,
        LOGIN = 500,
        LOGIN_RESULT = 500
    }
}
