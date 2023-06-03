using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LAN_Caro
{
    public abstract class Player_OBJ
    {
        public NetworkStream netStream;
        public TableManager tableManager;
        public abstract void ReceiveMessage(Socket tcpClient_Client);
        public abstract void messageSend(string dataS);
    }


    #region Client
    public class Client_OBJ : Player_OBJ
    {
        TcpClient tcpClient = new TcpClient();
        public Client_OBJ(TableManager table, string ipAddress)
        {
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), 8082);
                tcpClient.Connect(ipEndPoint);
                netStream = tcpClient.GetStream();
                tableManager = table;
                tableManager.rtbLog.Text += tableManager.tbIPAdress.Text + ":8082\nConnected!\n";
                Task.Run(() =>
                {
                    ReceiveMessage(tcpClient.Client);
                });
            }
            catch
            {
                tableManager.rtbLog.Text += "Error, Server not found!\n";
                return;
            }
        }

        ~Client_OBJ()
        {
            tcpClient.Close();
            netStream.Close();
        }


        public override void ReceiveMessage(Socket tcpClient_Client)
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
                tableManager.rtbLog.Text += "Receive: " + temp + "\n";
                if (temp == "")
                    continue;
                else if (temp.StartsWith("NG"))
                {
                    //tableManager.newGame();
                    continue;
                }
                string[] parts = temp.Split(':');
                int x = Int32.Parse(parts[0]);
                int y = Int32.Parse(parts[1]);
                tableManager.clickReceive(x, y);
            }
        }

        public override void messageSend(string dataS)
        {
            if (netStream != null)
            {
                tableManager.rtbLog.Text += "Send: " + dataS + "\n";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(dataS + "\n");
                netStream.Write(data, 0, data.Length);
            }

        }
    }
    #endregion

















    #region Server
    public class Server_OBJ : Player_OBJ
    {
        TcpListener tcpListener;
        IPEndPoint ipepServer;

        List<TcpClient> clients = new List<TcpClient>();

        public Server_OBJ(TableManager tableManager)
        {
            tableManager.rtbLog.Text += "Waiting connect...\n";
            ipepServer = new IPEndPoint(IPAddress.Any, 8082);
            tcpListener = new TcpListener(ipepServer);
            tcpListener.Start();
            Task.Run(() =>
            {
                AcceptConnection();
            });
            this.tableManager = tableManager;
        }

        public override void ReceiveMessage(Socket tcpClient_Client)
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
                tableManager.rtbLog.Text += "Receive: " + temp + "\n";
                if (temp == "")
                    continue;
                else if (temp.StartsWith("NG"))
                {
                    //tableManager.newGame();
                    continue;
                }

                string[] parts = temp.Split(':');
                int x = Int32.Parse(parts[0]);
                int y = Int32.Parse(parts[1]);
                tableManager.clickReceive(x, y);
            }
        }


        public override void messageSend(string message)
        {
            foreach (TcpClient client in clients)
            {
                netStream = client.GetStream();
                if (netStream != null)
                {
                    tableManager.rtbLog.Text += "Send: " + message + "\n";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    netStream.Write(data, 0, data.Length);
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
                    tableManager.rtbLog.Text += clientEndPoint + " Connected!\n";
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



    }
    #endregion
}