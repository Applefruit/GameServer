using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplayerServerUnity.Networking.LocalDatabaseServer;
using MultiplayerServerUnity.Networking.Converters;

namespace MultiplayerServerUnity.Networking.PackageHandlers
{
    public class MovementHandler
    {
        private LocalDatabase m_Localdatabase;

        public MovementHandler()
        {
            m_Localdatabase = UnityServer.Instance.LocalPlayerDatabase;
        }

        public void HandleMovementPackage(int ClientID, byte[] data)
        {
            ByteBuffer byteBuffer = new ByteBuffer();
            byteBuffer.WriteBytes(data);

            for (int i = 1; i < BaseInformationReader.Max_Players; i++)
            {
                if(m_Localdatabase.ActiveClients[i].ClientID == ClientID)
                {
                    int packageID = byteBuffer.ReadInteger();
                    int UniqueTokenRd = byteBuffer.ReadInteger();

                    byte[] PositionBytes = byteBuffer.ReadBytes(12); //Vector3 = 12 bytes ;) (3x4)
                    Vector3 position = Converter.ByteToVector3(PositionBytes);

                    CheckIfValidPosition(position, i);
                }
            }

            byteBuffer = null;
        }

        private void CheckIfValidPosition(Vector3 newPosition, int clientID)
        {
            if(Vector3.GetDistance(m_Localdatabase.ActiveClients[clientID].PlayerPosition, newPosition) < 1)
            {
                m_Localdatabase.ActiveClients[clientID].PlayerPosition = newPosition;
                return;
            } else
            {
                //RESET POSITION
                //SEND RETURN PACKAGE TO CLIENT
            }
        } 
    }
}
