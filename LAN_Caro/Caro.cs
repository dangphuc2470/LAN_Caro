﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace LAN_Caro
{
    public partial class Caro : Form
    {

        public Table tableManager;
        Player_OBJ ServerOrClient;
        ToolTip toolTip1;
        public int remainingTimeInSeconds;
        bool isPause = false;
        public Color PausePanelLabelColor = Color.Black;
        public Color PausePanelLabelColorHover = ColorTranslator.FromHtml("#F1A400");
        public Caro()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            remainingTimeInSeconds = 60;
            KeyPreview = true;
            toolTip1 = new ToolTip();
        }
        private void Caro_Load(object sender, EventArgs e)
        {
            #region Format Font
            lbTimer.Text = SecondToMinute(remainingTimeInSeconds.ToString());
            lbTimer.Parent = ptbBackgroundTimer;
            lblllMinSecond.Parent = ptbBackgroundTimer;

            foreach (CustomLabel label in pnPause2.Controls.OfType<CustomLabel>())
            {
                if (label.Name == "lbTesting2" || label.Name == "lbTesting1")
                    continue;
                else if (label.Name == "lbMenu")
                {
                    label.UseCustomFont("Arbuz.ttf", 40, FontStyle.Bold);
                    label.ForeColor = PausePanelLabelColorHover;
                    continue;
                }
                label.MouseEnter += PauseLabel_MouseEnter;
                label.MouseLeave += PauseLabel_MouseLeave;
                label.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
                label.ForeColor = PausePanelLabelColor;
                label.Tag = "0";
            }

            lbTimer.UseCustomFont("DS-DIGII.TTF", 35, FontStyle.Bold);
            lblllMinSecond.UseCustomFont("UI.ttf", 10, FontStyle.Bold);

            #endregion
            tableManager = new Table(pnTable, rtbLog, imgTurn, tbIPAdress, timer1, lbTimer, btReady,
                remainingTimeInSeconds, timer, this, lbNameClient, lbNameServer, ptbPlay, lbResume);


            tableManager.tableButtonClickedSend += TableManager_ButtonClickedSend;
            tableManager.DrawTable();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (isPause) return;
            tableManager.remainingTimeInSeconds--;
            lbTimer.Text = SecondToMinute(tableManager.remainingTimeInSeconds.ToString());
            // MessageBox.Show(lbTimer.Text);

            if (lbTimer.Text == "0:00")
            {
                //MessageBox.Show("asdasd");
                ServerOrClient.messageSend("Lose");
                tableManager.YouLose();
                timer.Enabled = false;
            }
        }


        private void TableManager_ButtonClickedSend(object sender, string text)
        {
            ServerOrClient.messageSend(text);
            tableManager.SwitchPlayer();
        }

        public void ShowPausePanel_Click(object sender, EventArgs e)
        {
            // Cập nhật giao diện người dùng trên thread chính
            //ptbPlay.Size = new Size(1480, 788);


            if (pnPause2.Tag.ToString() == "0" && tableManager.button_IsLoading == false)
            {
                ptbPausePlaceholderImage.Image = Properties.Resources.Picsart_23_06_07_08_41_09_453;
                ptbPausePlaceholderImage.Size = new Size(this.Width, this.Height);
                ptbPausePlaceholderImage.Location = new Point(0, 0);
                ptbPausePlaceholderImage.Visible = true;
                //ptbPlay.Dock = DockStyle.Fill;
                //ptbPlay.Location = new Point(0, 0);
                //ptbPlay.Visible = true;

                //HideLoadingImage();
                //tableManager.DarkColor();


                //pnPause2.Dock = DockStyle.Fill;
                //pnPause1.Size = new Size(this.Width, 788);
                pnPause2.Size = new Size(this.Width, this.Height);
                pnPause2.Location = new Point(0, 0);
                pnPause2.Parent = ptbPausePlaceholderImage;
                //MessageBox.Show("asd");
                pnPause2.Visible = true;
                pnPause2.BringToFront();
                pnPause2.Tag = "1";
                //ResetColor(lbResume);
            }
            else
            {

                Resume();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }


        #region Pause Panel


        private void PauseLabel_MouseEnter(object sender, EventArgs e)
        {
            CustomLabel label = (CustomLabel)sender;
            label.ForeColor = PausePanelLabelColorHover;
        }

        private void PauseLabel_MouseLeave(object sender, EventArgs e)
        {
            CustomLabel label = (CustomLabel)sender;
            if (label.Tag == "0")
                label.ForeColor = PausePanelLabelColor;
        }


        private void lbResume_Click(object sender, EventArgs e)
        {
            Resume();
        }

        private void Resume()
        {

            ResetColor();
            pnPause2.Visible = false;
            pnPause2.Tag = "0";
            ResetVisible();
            Task.Run(() =>
            {
                ptbPausePlaceholderImage.Image = Properties.Resources.Picsart_23_06_07_08_41_09_453;
                System.Threading.Thread.Sleep(10);
                ptbPausePlaceholderImage.Visible = false;
            });

            //tableManager.ResetColor();

        }

        private void lbOptions_Click(object sender, EventArgs e)
        {
            ResetColor(lbOptions);
            ResetVisible();
            lbRestart.Visible = true;
        }

        private void lbSettings_Click(object sender, EventArgs e)
        {
            ResetColor(lbSettings);
            ResetVisible();
        }


        private void lbMatchLog_Click(object sender, EventArgs e)
        {
            ResetVisible();
            ResetColor(lbMatchLog);
            rtbLog.Parent = ptbPausePlaceholderImage;
            rtbLog.Visible = true;
        }


        public void lbLeaveMatch_Click(object sender, EventArgs e)
        {
            this.Close();
            try
            {
                ServerOrClient.messageSend("Leave");
            }
            catch { }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// Reset tag và màu cho các label
        /// </summary>
        /// 
        private void ResetColor(CustomLabel thisLabel = null)
        {
            foreach (CustomLabel label in pnPause2.Controls.OfType<CustomLabel>())
            {
                if (label.Name == "lbMenu")
                    continue;
                label.ForeColor = PausePanelLabelColor;
                label.Tag = "0";
                if (thisLabel != null && thisLabel.Name != "lbResume")
                {
                    thisLabel.ForeColor = PausePanelLabelColorHover;
                    thisLabel.Tag = "1";
                }
            }
        }

        /// <summary>
        /// Ẩn tất cả tính năng trên Pause Panel
        /// </summary>
        private void ResetVisible()
        {
            rtbLog.Visible = false;
            lbPause.Visible = false;
            lbRandom.Visible = false;
            lbRestart.Visible = false;
            lbChangeTurn.Visible = false;
            //tableManager.DarkColor();

        }


        #endregion

        private void lbRestart_Click(object sender, EventArgs e)
        {
            Resume();
            tableManager.Restart(60);
            try
            {
                ServerOrClient.messageSend("Restart_" + remainingTimeInSeconds);
            }
            catch
            {
                MessageBox.Show("Could not send command to opponient, check your connection and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbPause_Click(object sender, EventArgs e)
        {
            ServerOrClient.messageSend("Pause");
            isPause = true;
        }
        private void lbRandom_Click(object sender, EventArgs e)
        {
            Resume();
            tableManager.RandomPatern();
        }


        /// <summary>
        /// Hiển thị các label trong Options chung với Restart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbRestart_VisibleChanged(object sender, EventArgs e)
        {
            lbRandom.Visible = lbRestart.Visible;
            lbPause.Visible = lbRestart.Visible;
            lbChangeTurn.Visible = lbRestart.Visible;
        }

        private void lbChangeTurn_Click(object sender, EventArgs e)
        {
            tableManager.SwitchPlayer();
            ServerOrClient.messageSend("Switch");
            Resume();
        }

        private void btReady_Click(object sender, EventArgs e)
        {
            if (btReady.Tag.ToString() == "0")
                return;
            ServerOrClient.ready();
            btReady.Tag = 1;
        }

        private void btReady_MouseHover(object sender, EventArgs e)
        {
            if (btReady.Tag.ToString() == "0")
                toolTip1.Show("The other player is not ready at the moment, or there is a connection problem.", btReady);
        }

        private void pnPause_VisibleChanged(object sender, EventArgs e)
        {
            if (!pnPause2.Visible)
            {
                foreach (CustomLabel label in pnPause2.Controls.OfType<CustomLabel>())
                    label.UseDefaultFont();
                lbTimer.UseCustomFont("DS-DIGII.TTF", 35, FontStyle.Bold);
                lblllMinSecond.UseCustomFont("UI.ttf", 10, FontStyle.Bold);
            }
            else
            {
                foreach (CustomLabel label in pnPause2.Controls.OfType<CustomLabel>())
                {
                    if (label.Name == "lbTesting2" || label.Name == "lbTesting1")
                        continue;
                    else if (label.Name == "lbMenu")
                    {
                        label.UseCustomFont("Arbuz.ttf", 40, FontStyle.Bold);
                        label.ForeColor = PausePanelLabelColorHover;
                        continue;
                    }
                    label.MouseEnter += PauseLabel_MouseEnter;
                    label.MouseLeave += PauseLabel_MouseLeave;
                    label.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
                    label.ForeColor = PausePanelLabelColor;
                    label.Tag = "0";
                }
                lbTimer.BackColor = Color.Transparent;
                lbTimer.UseDefaultFont();
                lblllMinSecond.UseDefaultFont();
            }

            if (isPause) //Tiếp tục timer mỗi khi panel pause bị ẩn
            {
                isPause = false;
                ServerOrClient.messageSend("Resume");
            }

            if (btReady.Tag.ToString() == "0")
                btReady.Visible = !pnPause2.Visible;
            ptbBackgroundTimer.Visible = !pnPause2.Visible;
            pnIPAddress.Visible = !pnPause2.Visible;


        }

        public static string SecondToMinute(string second)
        {
            int minute = int.Parse(second) / 60;
            int second_ = int.Parse(second) % 60;
            string second__ = (second_ == 0) ? "00" : second;
            return minute + ":" + second__;
        }

        private void btHost_Click(object sender, EventArgs e)
        {
            try
            {
                ServerOrClient = new Server_OBJ(tableManager);

                tableManager.setPlayer(0);
                btReady.Text = "PLAY";
                btClient.Visible = false;
                lblllChooseRole.Visible = false;
                btHost.Enabled = false;
                labelShowOrInput.Text = "Show this IP address to the client";
                // Lấy thông tin mạng của máy tính
                string ipv4Address = "";
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                cbbIP.Items.Add(ip.Address.ToString() + " " + ni.Name.ToString());
                                tbIPAdress.Text = ip.Address.ToString();
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(ipv4Address))
                    {
                        break;
                    }
                }

                tableManager.PlayerList[0].Name = lbNameServer.Text;
            }
            catch
            {
                MessageBox.Show("Server already running, please join as client instead or restart the game if you fell something was wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btClient_Click(object sender, EventArgs e)
        {
            if (tbIPAdress.Text == "")
            {
                tbIPAdress.Focus();
                return;
            }
            try
            {
                ServerOrClient = new Client_OBJ(tableManager, tbIPAdress.Text);
                btReady.Tag = 1;
                btReady.ForeColor = Color.White;
                btHost.Visible = false;
                lblllChooseRole.Visible = false;
                btClient.Enabled = false;
                MovePanelWithAnimation(btClient, btHost);
                btClient.Location = btHost.Location;
                tableManager.PlayerList[1].Name = lbNameClient.Text;

            }
            catch
            {
                tbIPAdress.Focus();
                MessageBox.Show("Server does not started yet or maybe you entered wrong IP address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MovePanelWithAnimation(Addon_Custom_Button pnMove, Addon_Custom_Button pnLocation)
        {
            Task.Run(() =>
            {
                int y = pnMove.Location.Y;
                while (y <= pnLocation.Location.Y)
                {
                    pnMove.Invoke(new Action(() =>
                    {
                        pnMove.Location = new Point(pnLocation.Location.X, y + 1);
                    }));
                    y = pnMove.Location.Y + 1;
                    if (y > 670)
                        Thread.Sleep(15);
                    else
                        Thread.Sleep(1);

                }
            });
        }

        private void cbbIP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbIPAdress.Text = cbbIP.SelectedItem.ToString().Substring(0, cbbIP.SelectedItem.ToString().IndexOf(" "));
        }

        public void SetLoadingImage(Image image)
        {
            ptbLoading.Image = image;
            ptbLoading.Visible = true;
            ptbLoading.Dock = DockStyle.Fill;
            ptbLoading.BringToFront();
        }

        public void HideLoadingImage()
        {
            ptbLoading.Visible = false;
        }
    }
}