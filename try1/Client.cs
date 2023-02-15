using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserClient {
    public class Client {
        private Socket localSocket { get; set; }
        private IPEndPoint remoteEndPoint { get; set; }
        private byte[] buffer { get; set; }
        public Client(string ipAddress, int port) {
            IPAddress iPAddress = IPAddress.Parse(ipAddress);
            remoteEndPoint = new IPEndPoint(iPAddress, port);
            //init socket
            localSocket = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        public void connect() {
            localSocket.Connect(remoteEndPoint);
        }

        public Socket getConn() 
            => localSocket;

        public byte[] getBuffer() => buffer;
}
   
}
