using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Networking
{
    enum clientStates
    {
        AWAIT_CONNECTION = 0,
        AWAIT_KEY = 1,
        AWAIT_AUTH = 2,
        LOGGEDIN = 3
    }
}
