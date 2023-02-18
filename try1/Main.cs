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
            browser.loadPage( "www.google.com" );
            Console.ReadLine();
        }
    }
}