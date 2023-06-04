using System.Drawing;
using System.Drawing.Text;

namespace LAN_Caro
{
    public partial class Caro : Form
    {

        TableManager tableManager;
        Player_OBJ ServerOrClient;
        public Caro()
        {
            InitializeComponent();
            KeyPreview = true;
            foreach (Addon_Custom_Button button in pnPause.Controls.OfType<Button>())
            {
                button.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
                button.ForeColor = Color.FromArgb(176, 177, 180);
                if (button.Name == "btMenuLabel")
                {
                    button.UseCustomFont("Arbuz.ttf", 40, FontStyle.Bold);
                    button.ForeColor = Color.White;
                }
            }

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

        private void Menu_Click(object sender, EventArgs e)
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
            tableManager.RandomPatern();
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


        #region Pause Panel
        private void PauseButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(62, 62, 62);
            button.ForeColor = Color.White;
        }


        private void PauseButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Transparent;
            if (button.Tag == "1")
                return;
            button.ForeColor = Color.FromArgb(176, 177, 180);

        }

        private void btResume_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Resume(button);
        }

        private void Resume(Button button)
        {
            ResetTag(button);
            pnPause.Visible = false;
            tableManager.ResetColor();
            ResetVisible();
            pnPause.Tag = "0";
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ResetTag(button);


        }

        private void btMatchLog_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ResetTag(button);

            rtbLog.Visible = true;
        }

        /// <summary>
        /// Reset tag và màu cho các button
        /// </summary>
        private void ResetTag(Button thisButton)
        {
            foreach (Addon_Custom_Button button in pnPause.Controls.OfType<Button>())
            {
                if (button.Name == "btMenuLabel")
                    continue;
                button.Tag = 0;
                button.ForeColor = Color.FromArgb(176, 177, 180);

            }
            thisButton.ForeColor = Color.White;
            thisButton.Tag = "1";
        }

        /// <summary>
        /// Ẩn tất cả tính năng trên Pause Panel
        /// </summary>
        private void ResetVisible()
        {
            rtbLog.Visible = false;

        }
        #endregion

        #region Disable MenuButton

        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(62, 62, 62);
            button.ForeColor = Color.White;
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.White;
        }

        private void btMenu_MouseClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(62, 62, 62);
            button.ForeColor = Color.White;
        }

        private void btMenu_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(62, 62, 62);
            button.ForeColor = Color.White;
        }
        #endregion

        private void Caro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (pnPause.Tag == "0")
                {
                    pnPause.Dock = DockStyle.Fill;
                    pnPause.Visible = true;
                    tableManager.DarkColor();
                    pnPause.Tag = "1";
                }
                else
                    Resume(btResume);
            }
        }
    }

}