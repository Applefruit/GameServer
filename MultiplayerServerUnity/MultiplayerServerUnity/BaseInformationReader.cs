using System;
using System.Linq;
using System.IO;
using System.Configuration;

namespace MultiplayerServerUnity
{
    public class BaseInformationReader
    {
        public static string IpAdress;
        public static int Server_Port;
        public static int Max_Players;

        public BaseInformationReader()
        {
            IpAdress = ConfigurationSettings.AppSettings["IpAdress"];
            Server_Port = int.Parse(ConfigurationSettings.AppSettings["Port"]);
            Max_Players = int.Parse(ConfigurationSettings.AppSettings["MaxPlayers"]);
        

        }

    }
}
