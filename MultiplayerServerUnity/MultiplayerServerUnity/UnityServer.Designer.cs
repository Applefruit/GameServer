namespace MultiplayerServerUnity
{
    partial class UnityServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnityServer));
            this.TB_ConsoleLog = new System.Windows.Forms.TextBox();
            this.LB_ConnectedPlayers = new System.Windows.Forms.Label();
            this.BT_ServerButton = new System.Windows.Forms.Button();
            this.Lb_TitleConsole = new System.Windows.Forms.Label();
            this.Tb_DebugIndex = new System.Windows.Forms.TextBox();
            this.Debug_Bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_ConsoleLog
            // 
            this.TB_ConsoleLog.Location = new System.Drawing.Point(12, 76);
            this.TB_ConsoleLog.Multiline = true;
            this.TB_ConsoleLog.Name = "TB_ConsoleLog";
            this.TB_ConsoleLog.Size = new System.Drawing.Size(674, 547);
            this.TB_ConsoleLog.TabIndex = 0;
            // 
            // LB_ConnectedPlayers
            // 
            this.LB_ConnectedPlayers.AutoSize = true;
            this.LB_ConnectedPlayers.Font = new System.Drawing.Font("Sitka Small", 24.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_ConnectedPlayers.Location = new System.Drawing.Point(146, 626);
            this.LB_ConnectedPlayers.Name = "LB_ConnectedPlayers";
            this.LB_ConnectedPlayers.Size = new System.Drawing.Size(365, 49);
            this.LB_ConnectedPlayers.TabIndex = 1;
            this.LB_ConnectedPlayers.Text = "Connected players: 0";
            // 
            // BT_ServerButton
            // 
            this.BT_ServerButton.Location = new System.Drawing.Point(12, 12);
            this.BT_ServerButton.Name = "BT_ServerButton";
            this.BT_ServerButton.Size = new System.Drawing.Size(157, 35);
            this.BT_ServerButton.TabIndex = 2;
            this.BT_ServerButton.Text = "Start/Stop Server";
            this.BT_ServerButton.UseVisualStyleBackColor = true;
            this.BT_ServerButton.Click += new System.EventHandler(this.BT_ServerButton_Click);
            // 
            // Lb_TitleConsole
            // 
            this.Lb_TitleConsole.AutoSize = true;
            this.Lb_TitleConsole.Font = new System.Drawing.Font("Sitka Small", 24.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TitleConsole.Location = new System.Drawing.Point(478, 9);
            this.Lb_TitleConsole.Name = "Lb_TitleConsole";
            this.Lb_TitleConsole.Size = new System.Drawing.Size(208, 49);
            this.Lb_TitleConsole.TabIndex = 3;
            this.Lb_TitleConsole.Text = "Console log";
            // 
            // Tb_DebugIndex
            // 
            this.Tb_DebugIndex.Location = new System.Drawing.Point(704, 651);
            this.Tb_DebugIndex.Name = "Tb_DebugIndex";
            this.Tb_DebugIndex.Size = new System.Drawing.Size(100, 20);
            this.Tb_DebugIndex.TabIndex = 4;
            // 
            // Debug_Bt
            // 
            this.Debug_Bt.Location = new System.Drawing.Point(704, 677);
            this.Debug_Bt.Name = "Debug_Bt";
            this.Debug_Bt.Size = new System.Drawing.Size(100, 23);
            this.Debug_Bt.TabIndex = 5;
            this.Debug_Bt.Text = "Send debug";
            this.Debug_Bt.UseVisualStyleBackColor = true;
            this.Debug_Bt.Click += new System.EventHandler(this.Debug_Bt_Click);
            // 
            // UnityServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 735);
            this.Controls.Add(this.Debug_Bt);
            this.Controls.Add(this.Tb_DebugIndex);
            this.Controls.Add(this.Lb_TitleConsole);
            this.Controls.Add(this.BT_ServerButton);
            this.Controls.Add(this.LB_ConnectedPlayers);
            this.Controls.Add(this.TB_ConsoleLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnityServer";
            this.Text = "UnityServer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_ConsoleLog;
        private System.Windows.Forms.Label LB_ConnectedPlayers;
        private System.Windows.Forms.Button BT_ServerButton;
        private System.Windows.Forms.Label Lb_TitleConsole;
        private System.Windows.Forms.TextBox Tb_DebugIndex;
        private System.Windows.Forms.Button Debug_Bt;
    }
}

