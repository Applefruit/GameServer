using System;
using System.Net;
using System.Net.Sockets;
using MultiplayerServerUnity.Networking.Receiving;
using MultiplayerServerUnity.MySQl;
using MultiplayerServerUnity.Networking.Sending;

namespace MultiplayerServerUnity.Networking
{
    public class BaseNetwork
    {
        public Client[] GameClients;

        public MySql MySQL;
        public NetworkSender NetworkSend;


        private NetworkReceiver m_NetworkReceiver;
        private TcpListener m_ServerListener;
        private UnityServer m_UnityServer;


        public void InitiliazeServer()
        {
            m_UnityServer = UnityServer.Instance;

            m_ServerListener = new TcpListener(IPAddress.Parse(BaseInformationReader.IpAdress), BaseInformationReader.Server_Port);
            m_ServerListener.Start();
            m_ServerListener.BeginAcceptTcpClient(OnAcceptNewClient, null);

            m_NetworkReceiver = new NetworkReceiver(this);
            NetworkSend = new NetworkSender(this);  

            MySQL = new MySql();
            MySQL.MySQLInit();
            m_UnityServer.AppendNewLog("The server has been initiliazed succesfully" + BaseInformationReader.Server_Port);

            InitiliazeClients();
        }

        private void InitiliazeClients()
        {
            GameClients = new Client[BaseInformationReader.Max_Players];

            for (int i = 1; i < BaseInformationReader.Max_Players; i++)
            {
                GameClients[i] = new Client();
            }

            m_UnityServer.AppendNewLog("All Clients have been setup correctly!");
        }

        private void OnAcceptNewClient(IAsyncResult result)
        {
            TcpClient client = m_ServerListener.EndAcceptTcpClient(result);
            client.NoDelay = false;

            m_ServerListener.BeginAcceptTcpClient(OnAcceptNewClient, null);

            for (int i = 1; i < BaseInformationReader.Max_Players; i++)
            {
                if(GameClients[i].Client_Socket == null)
                {
                    GameClients[i].Client_Socket = client;
                    GameClients[i].Client_Token = i;
                    GameClients[i].Client_IpAdress = client.Client.RemoteEndPoint.ToString();
                    GameClients[i].InitiliazeClient(m_NetworkReceiver);

                    m_UnityServer.AppendNewLog("A new player has joined! With ID: " + i + " From: " + GameClients[i].Client_IpAdress);


                    ByteBuffer byteBuffer = new ByteBuffer();
                    byteBuffer.WriteInteger(999); // 999 package
                    byteBuffer.WriteInteger(i);

                    NetworkSend.SendTo(i, byteBuffer.ToArray());

                    return;
                }
            }
        }
    }
}
