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

        Server_OBJ serverObj;
        Client_OBJ clientObj;
        public Caro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableManager.switchPlayer();
        }

        private void Caro_Load(object sender, EventArgs e)
        {
            tableManager = new TableManager(pnTable);
            tableManager.ButtonClicked += TableManager_ButtonClicked;
            tableManager.DrawTable();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (chbServer.CheckState == CheckState.Checked)
            {
                serverObj = new Server_OBJ(tableManager);
                isServerPlayer = 1;
                tableManager.setPlayer(isServerPlayer);
            }
            else
            {
                clientObj = new Client_OBJ(tableManager, tbIPAdress.Text);
            }

        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (isServerPlayer == 1)
            {
                serverObj.sendToClient(tbData.Text + "\n");
                tableManager.switchPlayer();
            }
            else
            {
                clientObj.messageSend(tbData.Text + "\n");
                tableManager.switchPlayer();
            }

        }
        private void TableManager_ButtonClicked(object sender, string text)
        {
            if (isServerPlayer == 1)
            {
                serverObj.sendToClient(text);
                tableManager.switchPlayer();
            }
            else
            {
                clientObj.messageSend(text);
                tableManager.switchPlayer();
            }
        }
    }
}

