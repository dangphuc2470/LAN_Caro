using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAN_Caro
{
    public partial class Caro : Form
    {

        int isServerPlayer = 0;
        TableManager tableManager;
        Both_OBJ ServerOrClient;
        public Caro()
        {
            InitializeComponent();


        }

        private void Caro_Load(object sender, EventArgs e)
        {
            tableManager = new TableManager(pnTable, lbStatus, imgTurn);
            tableManager.ButtonClicked += TableManager_ButtonClicked;
            tableManager.DrawTable();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (chbServer.CheckState == CheckState.Checked)
            {
                ServerOrClient = new Server_OBJ(tableManager);
                isServerPlayer = 1;
                tableManager.setPlayer(isServerPlayer);
            }
            else
            {
                ServerOrClient = new Client_OBJ(tableManager, tbIPAdress.Text);
            }
        }


        private void TableManager_ButtonClicked(object sender, string text)
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
