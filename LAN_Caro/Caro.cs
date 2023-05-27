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
        SocketManager socket;
        public Caro()
        {
            InitializeComponent();
            tableManager = new TableManager(pnTable);
            tableManager.DrawTable();
            socket = new SocketManager();
            tbIPAdress.Text = "127.0.0.1";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableManager.switchPlayer();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            socket.IP = tbIPAdress.Text;
            if (!socket.ConnectServer())
            {
                MessageBox.Show("Cant find server, creating a new server");
                socket.CreateServer();
                tableManager.playerInfo(1);
            }
            else
                Listen();

        }
        private void Caro_Shown(object sender, EventArgs e)
        {
            tbIPAdress.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(tbIPAdress.Text))
            {
                tbIPAdress.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        void Listen()
        {
            string data = (string)socket.Receive();
            MessageBox.Show(data);
        }

        private void rdButton_Click(object sender, EventArgs e)
        {
            //rdButton.Text = "Cancel";


        }
    }
}
