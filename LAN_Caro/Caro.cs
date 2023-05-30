﻿namespace LAN_Caro
{
    public partial class Caro : Form
    {

        TableManager tableManager;
        Both_OBJ ServerOrClient;
        public Caro()
        {
            InitializeComponent();

        private void Caro_Load(object sender, EventArgs e)
        {
            tableManager = new TableManager(pnTable, lbStatus, imgTurn);
            tableManager.tableButtonClickedSend += TableManager_ButtonClickedSend;
            tableManager.DrawTable();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (chbServer.CheckState == CheckState.Checked)
            {
                ServerOrClient = new Server_OBJ(tableManager);
                tableManager.setPlayer(0);
            }
            else
                ServerOrClient = new Client_OBJ(tableManager, tbIPAdress.Text);
        }


        private void TableManager_ButtonClickedSend(object sender, string text)
        {
            ServerOrClient.messageSend(text);
            tableManager.switchPlayer();
        }

        private void chbServer_CheckedChanged(object sender, EventArgs e)
        {
            tbIPAdress.Text = "127.0.0.1";
        }
    }
}
