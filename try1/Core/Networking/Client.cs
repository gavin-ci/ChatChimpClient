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
            Globals.packageHandler = new PackageHandler(localSocket);
            currentState = (int)ClientStates.AWAIT_CONNECTION;
            changePacketSize();
        }
        public void connect() {
            localSocket.Connect( remoteEndPoint );
        }

        public void startReceiving() {
            EndPoint remoteEndPoint = getConn().RemoteEndPoint!;
            getConn().BeginReceiveFrom(
                getBuffer(),
                0,
                getBuffer().Length,
                SocketFlags.None, ref remoteEndPoint,
                handlePacket,
                this
            );
        }

        private void handlePacket(IAsyncResult result) {
            Client client = (Client)result.AsyncState; // Object dat is mee gegeven in de functie
            client.getBuffer(); // data ontvangen
            ProcessPacket processPacket = new ProcessPacket(client);
        }

        public Socket getConn()
            => localSocket;

        public byte[] getBuffer()
            => buffer;

        public int getState()
            => currentState;

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
            Heartbeat heartbeat = new Heartbeat();
        }
    }

}
