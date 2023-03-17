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
using ChatChimpClient.Core.Readers.LaunchArgs;
using ChatChimpClient.Core.Gui.Browser.BrowserEvents;
using ChatChimpClient.Core.FileSystem;

namespace Networking
{

    class EntryPoint {//
        //initialize socket
        
        static void Main( string[] args ) {
            LaunchArgsReader reader = new LaunchArgsReader( args );
            Client client = new Client(reader.SearchArgsInfo("ip_address"), int.Parse(reader.SearchArgsInfo("port")));
            client.connect();
            Globals.client = client;
            Globals.fileLoader = new FileLoader( reader.SearchArgsInfo("assetsFolder") );
            Browser browser = new Browser();
            Globals.browser     = browser;

            //browser.loadDoc("<button onclick='LoginClient();'>test</button>");

            browser.loadDoc(@"
<input id='username'>
<input id='password'>
<button id='btn'>test</button>
<script>
document.getElementById(""btn"").addEventListener(""click"", () => LoginClient( document.getElementById('username').value, document.getElementById('password').value ));
</script>

");
            Console.ReadLine();
        }
    }
}
