using System;

namespace MultiplayerServerUnity.Networking.LocalDatabaseServer
{
    public class LocalDatabase
    {
        public PlayerDataStructure[] ActiveClients = new PlayerDataStructure[BaseInformationReader.Max_Players];

        public LocalDatabase()
        {
            for (int i = 1; i < ActiveClients.Length; i++)
            {
                ActiveClients[i] = new PlayerDataStructure();
            }

            UnityServer.Instance.AppendNewLog("LocalDatabase has been setup");
        }

        //TODO: Add paramater with the Unique ID from logging in.
        public void InitliazeLocalDataContainer(int client_Token, int client_ID)
        {
            for (int i = 1; i < ActiveClients.Length; i++)
            {
                if(!ActiveClients[i].Occupied)
                {
                    ActiveClients[i].ClientID = client_ID;
                    ActiveClients[i].UniqueID = client_Token;
                    ActiveClients[i].Occupied = true;

                    return;
                }
            }

            UnityServer.Instance.AppendNewLog("ok");
        }

    }

    public struct PlayerDataStructure
    {
        public Vector3 PlayerPosition;
        public int UniqueID;
        public int ClientID;
        public int Health;
        public bool Occupied;
    }
}
