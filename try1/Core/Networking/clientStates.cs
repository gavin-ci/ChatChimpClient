using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Networking
{
    enum clientStates
    {
        AWAIT_CONNECTION,
        AWAIT_KEY,
        AWAIT_AUTH
    }
}
