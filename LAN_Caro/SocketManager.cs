using System.Net;
using System.Net.Sockets;
using System.Text;
namespace LAN_Caro
{
    public abstract class Both_OBJ
    {
        public NetworkStream netStream;
        public TableManager tableManager;
        public abstract void ReceiveMessage(Socket tcpClient_Client);
        public abstract void messageSend(string dataS);
    }


    #region Client
    public class Client_OBJ : Both_OBJ
    {
        TcpClient tcpClient = new TcpClient();
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


        public override void ReceiveMessage(Socket tcpClient_Client)
        {
            int bytesReceived = 0;
            string data = "";
            byte[] recv = new byte[10];
            while (tcpClient_Client.Connected)
            {
                bytesReceived = tcpClient_Client.Receive(recv);
                data = Encoding.ASCII.GetString(recv);

                string[] parts = data.Split(':');
                int x = Int32.Parse(parts[0]);
                int y = Int32.Parse(parts[1]);
                tableManager.clickReceive(x, y);

            }
        }

        public override void messageSend(string dataS)
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
    public class Server_OBJ : Both_OBJ
    {
        TcpListener tcpListener;
        IPEndPoint ipepServer;

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


        public override void ReceiveMessage(Socket tcpClient_Client)
        {
            int bytesReceived = 0;
            string data = "";
            byte[] recv = new byte[10];
            while (tcpClient_Client.Connected)
            {
                bytesReceived = tcpClient_Client.Receive(recv);
                data = Encoding.ASCII.GetString(recv);

                if (tcpClient_Client.Poll(0, SelectMode.SelectRead) && tcpClient_Client.Available == 0)
                {
                    //Kiểm tra và đóng kết nối
                    MessageBox.Show("Client disconnected!\n");
                    tcpClient_Client.Close();
                }
                else
                {
                    string[] parts = data.Split(':');
                    int x = Int32.Parse(parts[0]);
                    int y = Int32.Parse(parts[1]);
                    tableManager.clickReceive(x, y);
                }
            }
        }


        public override void messageSend(string message)
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



    }
    #endregion
}