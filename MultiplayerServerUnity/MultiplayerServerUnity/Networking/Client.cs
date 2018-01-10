using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using MultiplayerServerUnity.Networking.Receiving;

namespace MultiplayerServerUnity.Networking
{
    public class Client
    {
        public int Client_Token;
        public string Client_IpAdress;
        public TcpClient Client_Socket;
        public NetworkStream Client_Stream;

        private NetworkReceiver m_NetworkReceiver;
        private byte[] m_Buffer;

        private const int BUFFERSIZE = 4096;

        public void InitiliazeClient(NetworkReceiver networkReceiver)
        {
            Client_Socket.ReceiveBufferSize = BUFFERSIZE;   //4096
            Client_Socket.SendBufferSize = BUFFERSIZE;      //4096

            Client_Stream = Client_Socket.GetStream();

            m_NetworkReceiver = networkReceiver;

            Array.Resize(ref m_Buffer, Client_Socket.ReceiveBufferSize);

            Client_Stream.BeginRead(m_Buffer, 0, Client_Socket.ReceiveBufferSize, OnReceiveData, null);
        }

        private void OnReceiveData(IAsyncResult result)
        {
            try
            {
                int readBytes = Client_Stream.EndRead(result);

                if (readBytes == 0 || Client_Socket == null)
                {
                    CloseConnection();
                    return;
                }

                byte[] tempBuffer = null;

                Array.Resize(ref tempBuffer, readBytes);

                Buffer.BlockCopy(m_Buffer, 0, tempBuffer, 0, readBytes);

                //Handle the incoming data
                m_NetworkReceiver.HandleData(m_Buffer, Client_Token);


                Client_Stream.BeginRead(m_Buffer, 0, Client_Socket.ReceiveBufferSize, OnReceiveData, null);
                

            }
            catch
            {
                CloseConnection();
            }
        }

        private void CloseConnection()
        {
            Client_Socket.Close();
            Client_Socket = null;
        }
    }
}
