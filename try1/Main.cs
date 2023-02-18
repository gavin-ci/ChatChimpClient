using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ChatChimpClient.Core.Gui;
using ChatChimpClient.Core.Networking;
using ChatChimpClient.Core.PacketHandlers;
using ChatChimpClient.Core.Gui.Forms;
using ChatChimpClient.Core.Gui.Browser;
using ChatChimpClient;

namespace Networking
{

    class EntryPoint {//
        //initialize socket
        
        static void Main( string[] args ) {
            Browser browser = new Browser();
            Globals.browser = browser;
            browser.loadDoc("<div style='width:100px;height:100px;border-style:solid;'></div>");
            Console.ReadLine();
        }
    }
}