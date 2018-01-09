using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiplayerServerUnity.Networking;
using MultiplayerServerUnity.Networking.LocalDatabaseServer;
using MultiplayerServerUnity.Networking.Send_ReceiveEnums;

namespace MultiplayerServerUnity
{
    public partial class UnityServer : Form
    {
        public static UnityServer Instance;

        public BaseNetwork NetworkBase;
        public LocalDatabase LocalPlayerDatabase;

        public UnityServer()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaseInformationReader baseInformation = new BaseInformationReader();

            NetworkBase = new BaseNetwork();
            LocalPlayerDatabase = new LocalDatabase();
        }

        /// <summary>
        /// Add a new log in to the console.
        /// </summary>
        /// <param name="txt"></param>
        public void AppendNewLog(string txt)
        {
            string prefix = DateTime.Now + ": ";
            string appendString = prefix + txt + "\n";

            if (TB_ConsoleLog.InvokeRequired)
                Invoke(new Action<string>(s => TB_ConsoleLog.AppendText(s)), appendString);
            else TB_ConsoleLog.AppendText(appendString);
        }

        /// <summary>
        /// Initliaze the server , (Starting up on click)
        /// </summary>
        /// <param name="sender"></param>
        private void BT_ServerButton_Click(object sender, EventArgs e)
        {
            NetworkBase.InitiliazeServer();
        }

        private void Debug_Bt_Click(object sender, EventArgs e)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)PackageHandlerEnum.DebugMessage);

            NetworkBase.NetworkSend.SendTo(int.Parse(Tb_DebugIndex.Text), buffer.ToArray());

            for (int i = 1; i < BaseInformationReader.Max_Players; i++)
            {
                if (LocalPlayerDatabase.ActiveClients[i].Occupied)
                {
                    AppendNewLog(LocalPlayerDatabase.ActiveClients[i].UniqueID.ToString());
                    AppendNewLog(LocalPlayerDatabase.ActiveClients[i].ClientID.ToString());
                }
            }
        }
    }
}
