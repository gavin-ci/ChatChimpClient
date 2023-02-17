using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ChatChimpClient.Core.Gui;
using ChatChimpClient.Core.Networking;
using ChatChimpClient.Core.PacketHandlers;
using ChatChimpClient.Core.Gui.Forms;
namespace Networking
{

    class EntryPoint {//
        //initialize socket
        [STAThread]
        static void Main(string[] args) {
            BaseForm view = new LoginForm();
            ViewPort viewPort = new ViewPort(view);
            Console.ReadLine();
        }
    }
}