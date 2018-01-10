using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplayerServerUnity.Networking.LocalDatabaseServer;
using MultiplayerServerUnity.Networking.Sending;
using MultiplayerServerUnity.Networking.Send_ReceiveEnums;

namespace MultiplayerServerUnity.Networking.PackageHandlers
{
    public class LoginHandler
    {
        private int m_ClientID;
        private int m_LoginToken;
        private int m_PacketID;

        private UnityServer m_UnityServer;
        private LocalDatabase m_LocalDatabase;

        public LoginHandler()
        {
            m_UnityServer = UnityServer.Instance;
            m_LocalDatabase = m_UnityServer.LocalPlayerDatabase;
        }

        /// <summary>
        /// Receives login packet from a client. Then return a package to the game client.
        /// </summary>
        public void HandleLogin(byte[] data)
        {
            ByteBuffer byteBuffer = new ByteBuffer();
            byteBuffer.WriteBytes(data);

            m_PacketID = byteBuffer.ReadInteger();
            m_LoginToken = byteBuffer.ReadInteger();
            m_ClientID = byteBuffer.ReadInteger();


            ProccessLogin(m_LoginToken, m_ClientID);
        }

        //TODO: Check if unique client token exists in database :)
        private void ProccessLogin(int LoginToken, int ClientID)
        {

            m_UnityServer.AppendNewLog("ClientID: " + m_ClientID + "|| Unique token: " + m_LoginToken);
            for (int i = 1; i < BaseInformationReader.Max_Players; i++)
            {
                if(i == ClientID)
                {
                    m_LocalDatabase.InitliazeLocalDataContainer(m_LoginToken, ClientID);
                    SendReturnPackageToClient(ClientID, LoginToken);
                }
            }
        }

        private void SendReturnPackageToClient(int clientID, int loginToken)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)PackageHandlerEnum.LoginPacket);
            buffer.WriteInteger(clientID);
            m_UnityServer.NetworkBase.NetworkSend.SendTo(clientID, buffer.ToArray());
        }
    }
}
