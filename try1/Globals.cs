using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.Gui;
using ChatChimpClient.Core.Gui.Browser;
using ChatChimpClient.Core.Networking;

namespace ChatChimpClient
{
    public static class Globals
    {
        public static Client client { get; set; }
        public static Browser browser { get; set; }
    }
}
