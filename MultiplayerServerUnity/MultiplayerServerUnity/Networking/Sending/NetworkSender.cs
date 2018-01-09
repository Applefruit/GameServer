﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerServerUnity.Networking.Sending
{
    public class NetworkSender
    {

        private BaseNetwork m_BaseNetwork;
        private UnityServer m_UnityServer;

        public NetworkSender(BaseNetwork baseNetwork)
        {
            m_BaseNetwork = baseNetwork;
            m_UnityServer = UnityServer.Instance;
        }

        /// <summary>
        /// Send a data to a specific client.
        /// </summary>
        public void SendTo(int client_Index, byte[] data)
        {

            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);

            if (m_BaseNetwork.GameClients[client_Index].Client_Socket != null)
                m_BaseNetwork.GameClients[client_Index].Client_Stream.BeginWrite(buffer.ToArray(), 0, buffer.ToArray().Length, null, null);
            else m_UnityServer.AppendNewLog("Something went wrong when sending a packet to client: " + client_Index);

            buffer = null;
        }

        /// <summary>
        /// Sends the data to all active clients
        /// </summary>
        public async void SendToAll(byte[] data)
        {
            for (int i = 1; i < m_BaseNetwork.GameClients.Length; i++)
            {
                if (m_BaseNetwork.GameClients[i].Client_Socket != null)
                {
                    await Task.Delay(1000);
                    SendTo(i, data);
                }
            }
        }

        /// <summary>
        /// Sends the data to all active clients expect one.
        /// </summary>
        public void SendToAllExcept(int exception_Client_Index, byte[] data)
        {
            for (int i = 1; i < m_BaseNetwork.GameClients.Length; i++)
            {
                if (m_BaseNetwork.GameClients[i].Client_Socket != null)
                {
                    if(i != exception_Client_Index)
                        SendTo(i, data);
                }
            }
        }
    }
}
