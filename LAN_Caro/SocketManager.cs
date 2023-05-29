using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace LAN_Caro
{
    #region Client
    public class Client_OBJ
    {
        TcpClient tcpClient = new TcpClient();
        NetworkStream netStream;
        TableManager tableManager;
        public Client_OBJ(TableManager tableManager, string ipAddress)
        {
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), 8082);
                tcpClient.Connect(ipEndPoint);
                netStream = tcpClient.GetStream();
                this.tableManager = tableManager;
                Task.Run(() =>
                {
                    ReceiveMessage(tcpClient.Client);
                });
            }
            catch
            {
                MessageBox.Show("Server must be started first!", "Error");
            }
        }

        ~Client_OBJ()
        {
            tcpClient.Close();
            netStream.Close();
        }


        public void ReceiveMessage(Socket tcpClient_Client)
        {
            int bytesReceived = 0;
            byte[] recv = new byte[1];
            while (tcpClient_Client.Connected)
            {
                string Chr;
                string temp = "";
                while (true)
                {

                    bytesReceived = tcpClient_Client.Receive(recv);
                    Chr = Encoding.UTF8.GetString(recv);
                    if (Chr == "\n")
                        break;
                    temp += Chr;

                }
                if (temp == "")
                    continue;
                string[] parts = temp.Split(':');
                int x = Int32.Parse(parts[0]);
                int y = Int32.Parse(parts[1]);
                tableManager.clickReceive(x, y);
                //tableManager.switchPlayer();


                //MessageBox.Show("message in client form" + temp);
                //tableManager.switchPlayer();

            }
        }

        public void messageSend(string dataS)
        {
            if (netStream != null)
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(dataS + "\n");
                netStream.Write(data, 0, data.Length);
            }

        }
    }
    #endregion













    #region Server
    public class Server_OBJ
    {
        TcpListener tcpListener;
        IPEndPoint ipepServer;
        NetworkStream netStream;
        TableManager tableManager;
        List<TcpClient> clients = new List<TcpClient>();

        public Server_OBJ(TableManager tableManager)
        {
            MessageBox.Show("Waiting connect...\n");
            ipepServer = new IPEndPoint(IPAddress.Any, 8082);
            tcpListener = new TcpListener(ipepServer);
            tcpListener.Start();
            Task.Run(() =>
            {
                AcceptConnection();
            });
            this.tableManager = tableManager;
        }


        public void ReceiveMessage(Socket tcpClient_Client)
        {
            int bytesReceived = 0;
            byte[] recv = new byte[1];
            while (tcpClient_Client.Connected)
            {
                string Chr;
                string temp = "";
                while (true)
                {

                    bytesReceived = tcpClient_Client.Receive(recv);
                    Chr = Encoding.UTF8.GetString(recv);
                    if (Chr == "\n")
                        break;
                    temp += Chr;

                }
                if (tcpClient_Client.Poll(0, SelectMode.SelectRead) && tcpClient_Client.Available == 0)
                {
                    //Kiểm tra và đóng kết nối
                    MessageBox.Show("Client disconnected!\n");
                    tcpClient_Client.Close();
                }
                else
                {
                    if (temp == "")
                        continue;
                    string[] parts = temp.Split(':');
                    int x = Int32.Parse(parts[0]);
                    int y = Int32.Parse(parts[1]);
                    tableManager.clickReceive(x, y);
                }
            }
        }

        public void AcceptConnection()
        {
            while (true)
            {
                try
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    clients.Add(tcpClient); // thêm client vào danh sách
                    IPEndPoint clientEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
                    string clientIPAddress = clientEndPoint.ToString();
                    MessageBox.Show(clientIPAddress + " connected!\n");
                    Task.Run(() =>
                    {
                        ReceiveMessage(tcpClient.Client);
                    });
                }
                catch (Exception ex)
                {
                    break;
                }
            }
        }

        public void sendToClient(string message)
        {
            foreach (TcpClient client in clients)
            {
                netStream = client.GetStream();
                if (netStream != null)
                {
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    netStream.Write(data, 0, data.Length);
                }
            }
        }

      

    }
    #endregion
}