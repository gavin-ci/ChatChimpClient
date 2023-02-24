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
        LOGIN_RESULT = 3,
        GET_KEY = 4
    }

    enum netSizes {
        CONNECT = 60,
        LOGIN_RESULT = 130,
        GET_KEY = 120,
        LOGGEDIN = 6024
    }
}
