using System.Drawing;
using System.Drawing.Text;

namespace LAN_Caro
{
    public partial class Caro : Form
    {

        TableManager tableManager;
        Player_OBJ ServerOrClient;
        Font customfont;


        public Caro()
        {
            InitializeComponent();
            btContinue.UseCustomFont("UI.ttf", 35, FontStyle.Bold);

        }
        private void Caro_Load(object sender, EventArgs e)
        {
            tableManager = new TableManager(pnTable, rtbLog, imgTurn, tbIPAdress);
            tableManager.tableButtonClickedSend += TableManager_ButtonClickedSend;
            tableManager.DrawTable();
            Task.Run(() =>
            {
                tableManager.UpdateColor(Color.Silver);

            });
        }

        private void Connect_Click(object sender, EventArgs e)
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
            tableManager.SwitchPlayer();
        }

        private void chbServer_CheckedChanged(object sender, EventArgs e)
        {
            tbIPAdress.Text = "127.0.0.1";
        }

        private void Pause_Click(object sender, EventArgs e)
        {

            pnPause.Dock = DockStyle.Fill;
            pnPause.Visible = true;
            tableManager.DarkColor();


        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            ServerOrClient.messageSend("NG");
            tableManager.NewGame();
        }

        private void RandomPattern_Click(object sender, EventArgs e)
        {
            tableManager.UpdateCorlorTest(Color.Silver);
        }

        private void SwitchPlayer_Click(object sender, EventArgs e)
        {
            tableManager.SwitchPlayer();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            //tableManager.UpdateColor(Color.Wheat);

            //Task.Run(() =>
            //{
            //});
        }

        private void btMatchLog_Click(object sender, EventArgs e)
        {
            rtbLog.Visible = true;
        }
    }
}
