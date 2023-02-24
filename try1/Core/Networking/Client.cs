using System.Net.Sockets;
using System.Net;
using ChatChimpClient.Core.Networking.Packets;
using ChatChimpClient.Core.PacketHandlers;

namespace ChatChimpClient.Core.Networking {
    public class Client {
        private Socket localSocket { get; set; }
        private IPEndPoint remoteEndPoint { get; set; }
        private ClientStates currentState { get; set; }
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
            currentState = ClientStates.AWAIT_CONNECTION;
            changePacketSize();
        }
        public void connect() {
            localSocket.Connect( remoteEndPoint );
        }

        public Socket getConn()
            => localSocket;

        public byte[] getBuffer()
            => buffer;

        public void login( string username, string password )
        {
            //PacketHandlers.PackageCreator creator = new PacketHandlers.PackageCreator(1000, 2, this);
            PackageWriter writer = new PackageWriter();
            writer.createHeader(18 + username.Length + password.Length, 2);
            writer.writeInt(username.Length);
            writer.writeString(username);
            writer.writeInt(password.Length);
            writer.writeString(password);
            localSocket.Send(writer.getData());
        }

        public void changePacketSize() {
            switch (currentState) {
                default:
                    buffer = new byte[(int)netSizes.CONNECT];
                    break;
                case (ClientStates)(int)ClientStates.AWAIT_KEY:
                    buffer = new byte[(int)netSizes.GET_KEY];
                    break;
                case (ClientStates)(int)ClientStates.AWAIT_AUTH:
                    buffer = new byte[(int)netSizes.LOGIN_RESULT];
                    break;
                case (ClientStates)(int)ClientStates.LOGGEDIN:
                    buffer = new byte[(int)netSizes.LOGGEDIN];
                    break;
            }
            GC.Collect();
        }
    }

}
