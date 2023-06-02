using System.Drawing;
namespace LAN_Caro
{
    public partial class Caro : Form
    {

        TableManager tableManager;
        Player_OBJ ServerOrClient;
        public Caro()
        {
            InitializeComponent();
        }
        private void Caro_Load(object sender, EventArgs e)
        {
            tableManager = new TableManager(pnTable, rtbLog, imgTurn, tbIPAdress);
            tableManager.tableButtonClickedSend += TableManager_ButtonClickedSend;
            tableManager.DrawTable();
            Task.Run(() =>
            {
                tableManager.UpdateColor(Color.Wheat);

            });
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

        private void addon_Custom_Button1_Click(object sender, EventArgs e)
        {

            panel1.Dock = DockStyle.Fill;
            panel1.Visible = true;
            tableManager.resetColor();
        }

        private void btNewGame_Click(object sender, EventArgs e)
        {
            ServerOrClient.messageSend("NG");
            tableManager.newGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableManager.UpdateCorlorTest(Color.LightGreen);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableManager.switchPlayer();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableManager.UpdateColor(Color.Wheat);
            panel1.Visible = false;
            //Task.Run(() =>
            //{
            //});
        }
    }
}
