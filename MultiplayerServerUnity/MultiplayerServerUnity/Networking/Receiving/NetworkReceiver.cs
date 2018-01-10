using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplayerServerUnity.Networking.Send_ReceiveEnums;
using MultiplayerServerUnity.Networking.PackageHandlers;

namespace MultiplayerServerUnity.Networking.Receiving
{
    public class NetworkReceiver
    {
        private UnityServer m_UnityServer;

        private int m_PacketID;
        private int m_ClientToken;

        private BaseNetwork m_BaseNetwork;

        private LoginHandler m_LoginHandler;
        private MovementHandler m_MovementHandler;

        public NetworkReceiver(BaseNetwork baseNetwork)
        {
            m_UnityServer = UnityServer.Instance;
            m_BaseNetwork = baseNetwork;

            m_LoginHandler = new LoginHandler();
            m_MovementHandler = new MovementHandler();
        }

        public void HandleData(byte[] data, int client)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);

            m_PacketID = buffer.ReadInteger();
            m_ClientToken = buffer.ReadInteger();

            buffer = null;

            if (m_PacketID == 0)
            {
                m_UnityServer.AppendNewLog("A bad package was send from client: " + m_ClientToken);
                return;
            }
            PacketHandler(m_ClientToken, m_PacketID, data);
        }


        private void PacketHandler(int Client_Token, int Package_ID, byte[] Data)
        {
            PackageHandlerEnum package;

            package = (PackageHandlerEnum) Package_ID;

            switch (package)
            {
                case PackageHandlerEnum.DebugMessage:
                    m_UnityServer.AppendNewLog("A debug message has been received correctly from: " + m_ClientToken + " - IP: " + m_BaseNetwork.GameClients[m_ClientToken].Client_IpAdress);
                    break;
                case PackageHandlerEnum.LoginPacket:
                    m_LoginHandler.HandleLogin(Data);
                    break;
                case PackageHandlerEnum.TransformPacket:
                    m_MovementHandler.HandleMovementPackage(m_ClientToken, Data);
                    break;

            }
        }
    }
}
