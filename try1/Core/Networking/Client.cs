using System.Net.Sockets;
using System.Net;
using ChatChimpClient.Core.Networking.Packets;
using ChatChimpClient.Core.PacketHandlers;
using System.Timers;

namespace ChatChimpClient.Core.Networking {
    public class Client {
        private Socket localSocket { get; set; }
        private IPEndPoint remoteEndPoint { get; set; }
        private int currentState { get; set; }
        private System.Timers.Timer MrHEARTBEEEEEEEEEEEEEAST { get; set; }
        private byte[] buffer { get; set; }
        public Client( string ipAddress, int port ) {
            IPAddress iPAddress = IPAddress.Parse( ipAddress );
            remoteEndPoint = new IPEndPoint( iPAddress, port );
            localSocket = new Socket(
                iPAddress.AddressFamily, 
                SocketType.Stream, 
                ProtocolType.Tcp
            );
            currentState = (int)ClientStates.AWAIT_CONNECTION;
            changePacketSize();
        }
        public void connect() {
            localSocket.Connect( remoteEndPoint );
        }

        public Socket getConn()
            => localSocket;

        public byte[] getBuffer()
            => buffer;

        public int getState()
            => currentState;

        public void login( string username, string password )
        {
            //PacketHandlers.PackageCreator creator = new PacketHandlers.PackageCreator(1000, 2, this);
            PackageWriter writer = new PackageWriter();
            writer.createHeader(18 + username.Length + password.Length, 2);
            writer.writeString(username);
            writer.writeString(password);
            localSocket.Send(writer.getData());
        }

        public void changePacketSize() {
            switch (currentState) {
                default:
                    buffer = new byte[(int)netSizes.CONNECT];
                    break;
                case (int)ClientStates.AWAIT_KEY:
                    buffer = new byte[(int)netSizes.GET_KEY];
                    break;
                case (int)ClientStates.AWAIT_AUTH:
                    buffer = new byte[(int)netSizes.LOGIN_RESULT];
                    break;
                case (int)ClientStates.LOGGEDIN:
                    buffer = new byte[(int)netSizes.LOGGEDIN];
                    break;
            }
            GC.Collect();
        }

        public void startTimer()
        {
            MrHEARTBEEEEEEEEEEEEEAST = new System.Timers.Timer(2000);
            MrHEARTBEEEEEEEEEEEEEAST.Elapsed += sendBeat;
        }

        public void sendBeat(object? source, ElapsedEventArgs e)
        {
            PackageWriter writer = new PackageWriter();
            Heartbeat heartbeat = new Heartbeat(writer);
            localSocket.Send(writer.getData());
        }
    }

}
