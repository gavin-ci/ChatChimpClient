﻿using System.Net.Sockets;
using System.Net;

namespace ChatChimpClient.Core.Networking
{
    public class Client
    {
        private Socket localSocket { get; set; }
        private IPEndPoint remoteEndPoint { get; set; }
        private byte[] buffer { get; set; }
        public Client(string ipAddress, int port)
        {
            IPAddress iPAddress = IPAddress.Parse(ipAddress);
            remoteEndPoint = new IPEndPoint(iPAddress, port);
            //init socket
            localSocket = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            buffer = new byte[6000];
        }
        public void connect()
        {
            localSocket.Connect(remoteEndPoint);
        }

        public Socket getConn()
            => localSocket;

        public byte[] getBuffer()
            => buffer;
    }

}