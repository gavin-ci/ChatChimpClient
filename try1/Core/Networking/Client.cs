using System.Net.Sockets;
using System.Net;
using ChatChimpClient.Core.Networking.Packets;

namespace ChatChimpClient.Core.Networking {
    public class Client {
        private Socket localSocket { get; set; }
        private IPEndPoint remoteEndPoint { get; set; }
        private clientStates currentState { get; set; }
        private byte[] buffer { get; set; }
        public Client( string ipAddress, int port ) {
            IPAddress iPAddress = IPAddress.Parse( ipAddress );
            remoteEndPoint = new IPEndPoint( iPAddress, port );
            //init socket
            localSocket = new Socket(
                iPAddress.AddressFamily, 
                SocketType.Stream, 
                ProtocolType.Tcp
            );
            currentState = clientStates.AWAIT_CONNECTION;
            buffer = new byte[300];
        }
        public void connect() {
            localSocket.Connect( remoteEndPoint );
        }

        public Socket getConn()
            => localSocket;

        public byte[] getBuffer()
            => buffer;

        public void login()
        {
            PacketHandlers.PackageCreator creator = new PacketHandlers.PackageCreator(1000, 2, this);
            localSocket.Send(buffer);
        }

        public void changePacketSize() {
            switch (currentState) {
                case (int)clientStates.AWAIT_CONNECTION:
                    buffer = new byte[(int)packetSizes.CONNECT];
                    break;
                case (clientStates)(int)clientStates.AWAIT_KEY:
                    break;
            }
            GC.Collect();
        }
    }

}
