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
            initSocket();
            Console.ReadLine();
        }
        //connect
        static void initSocket() {
            Client client = new Client("127.0.0.1", 25565);
            client.connect();
            new Thread(() => startReceiving(client)).Start();
            client.login();
        }

        static void startReceiving( Client client)
        {
            EndPoint remoteEndPoint = client.getConn().RemoteEndPoint!;
            client.getConn().BeginReceiveFrom(
                client.getBuffer(), 
                0, 
                client.getBuffer().Length, 
                SocketFlags.None, ref remoteEndPoint, 
                handlePacket, 
                client
            );
        }

        static void handlePacket( IAsyncResult result) {
            Client client = (Client)result.AsyncState; // Object dat is mee gegeven in de functie
            client.getBuffer(); // data ontvangen
            ProcessPacket processPacket = new ProcessPacket(client);
        }
    }
}
