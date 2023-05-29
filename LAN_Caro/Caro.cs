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
            socket = new SocketManager();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableManager.switchPlayer();
        }

        private void Caro_Load(object sender, EventArgs e)
        {
            tableManager = new TableManager(pnTable);
            tableManager.DrawTable(isServerPlayer);
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            socket.IP = tbIPAdress.Text;
            if (!socket.ConnectServer())
            {
                socket.CreateServer();

                Thread listenThread = new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        try
                        {
                            Listen();
                            break;
                        }
                        catch
                        {

                        }
                    }

                });
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            else
            {
                Thread listenThread = new Thread(() =>
                {
                    Listen();
                });
                listenThread.IsBackground = true;
                listenThread.Start();

                socket.Send("Thông tin từ Client");
            }
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

    }
}
