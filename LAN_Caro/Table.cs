using System.Collections.Generic;
using System.Windows.Forms;

namespace LAN_Caro
{
    public class Table
    {
        public int isClientPlayer = 1;
        public int isClientTurn;
        public static int SQUARE_SIZE = 40;
        public static int TABLE_WIDTH = 25;
        public static int TABLE_HEIGHT = 17;
        public int remainingTimeInSeconds;
        public bool isEndGame = false;
        public bool button_IsLoading = true;
        public Color backColorNormal = Color.FromArgb(235, 240, 250);
        public Color backColorDark = Color.FromArgb(69, 70, 73);
        public Color borderColorNormal = Color.Silver;
        public RichTextBox rtbLog;
        public PictureBox imgTurn;
        public TextBox tbIPAdress;
        public Panel pnTable;
        public System.Windows.Forms.Timer timer;
        public Label lbTimer;
        public Addon_Custom_Button btReady;
        public Caro caro1;
        public TextBox tbClientName;
        public TextBox tbServerName;
        public PictureBox ptbPlay;
        public List<Player> PlayerList { get; set; }
        public bool IsEndGame { get => isEndGame; set => isEndGame = value; }

        public List<List<Button>> buttonList = new List<List<Button>>();

        public Table(Panel pnTable, RichTextBox rtbLog, PictureBox imgTurn, TextBox tbIPAdress,
                            System.Windows.Forms.Timer timer, Label lbTimer,
                            Addon_Custom_Button btReady, int remainingTimeInSeconds, System.Windows.Forms.Timer timer2, Caro caro1, 
                            TextBox tbClientName, TextBox tbServerName, PictureBox ptbPlay)
        {
            this.ptbPlay = ptbPlay;
            this.tbClientName = tbClientName;
            this.tbServerName = tbServerName;
            this.caro1 = caro1;
            this.pnTable = pnTable;
            this.rtbLog = rtbLog;
            this.imgTurn = imgTurn;
            this.tbIPAdress = tbIPAdress;
            this.lbTimer = lbTimer;
            this.btReady = btReady;
            //this.lbTimer.SizeChanged += lbTimer_SizeChanged;
            this.remainingTimeInSeconds = remainingTimeInSeconds;
            PlayerList = new List<Player>()
            {
                new Player("PHÚC", Properties.Resources.x, Properties.Resources.xd),
                new Player("ĐĂNG", Properties.Resources.o, Properties.Resources.od),
            };
            isClientTurn = 0;
            this.timer = timer2;
            this.ptbPlay = ptbPlay;
        }


        #region Xử lí bàn cờ
        public void DrawTable()
        {
            Button lastButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < TABLE_HEIGHT; i++)
            {
                buttonList.Add(new List<Button>());
                for (int j = 0; j < TABLE_WIDTH; j++)
                {
                    Button button = new Button()
                    {
                        BackColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Width = SQUARE_SIZE,
                        Height = SQUARE_SIZE,
                        Location = new Point(lastButton.Location.X + lastButton.Width, lastButton.Location.Y),
                        Name = "bt" + j + "_" + i,

                    };
                    button.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
                    button.Parent = pnTable;
                    button.BackColor = Color.FromArgb(0, 0, 0, 0);
                    button.Click += btn_Click;
                    pnTable.Controls.Add(button);
                    buttonList[i].Add(button);
                    lastButton = button;
                }
                lastButton.Location = new Point(0, lastButton.Location.Y + SQUARE_SIZE);
                lastButton.Width = 0;
                lastButton.Height = 0;
            }

            //UpdateColor(borderColorNormal);

        }
        public event EventHandler<string> tableButtonClickedSend; //Gửi dữ liệu sang form

        #region Click
        public void btn_Click(object sender, EventArgs e)
        {
            if (isClientPlayer != isClientTurn || btReady.Tag.ToString() == "0" || isEndGame == true)  //Nếu chưa tới lượt, chưa ready hoặc đã kết thúc game thì không thể nhấn nút
                return;
            Button? button = sender as Button;
            int index = button.Name.IndexOf("_");
            int x = Int32.Parse(button.Name.Substring(2, index - 2));
            int y = Int32.Parse(button.Name.Substring(index + 1));
            if (buttonList[y][x].Image != null)
                return;
            buttonList[y][x].Image = PlayerList[isClientTurn].Image;

            if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
            {
                MessageBox.Show("WIN");
                IsEndGame = true;
            }
            tableButtonClickedSend?.Invoke(this, x + ":" + y);
        }

        public void clickReceive(int x, int y)
        {
            if (buttonList[y][x].Image != null)
                return;
            buttonList[y][x].Image = PlayerList[isClientTurn].Image;

            if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
            {
                MessageBox.Show("LOSE");
                IsEndGame = true;
            }
            SwitchPlayer();
        }

        #endregion

        public void setPlayer(int isClientPlayer)
        {
            this.isClientPlayer = isClientPlayer;
        }

        public void SwitchPlayer()
        {
            isClientTurn = isClientTurn == 0 ? 1 : 0;
            imgTurn.Image = PlayerList[isClientTurn].Image;
            Size size = imgTurn.Size;
            imgTurn.Size = new Size(size.Width + 1, size.Height);
            if (isClientPlayer == isClientTurn && !IsEndGame)
            {
                StartTimer();
            }
            else StopTimer();
        }


        #endregion









        #region Kiểm tra thắng thua
        public bool countHorizontal(int x, int y)
        {
            Image thisButtonImage = buttonList[y][x].Image;
            int count = 0;
            for (int i = x - 1; i >= 0; i--)
            {
                if (buttonList[y][i].Image == thisButtonImage)
                    count++;
                else
                    break;
            }

            for (int i = x + 1; i < TABLE_WIDTH; i++)
            {
                if (buttonList[y][i].Image == thisButtonImage)
                    count++;
                else
                    break;
            }

            if (count >= 4)
            {
                for (int i = x - 1; i >= 0; i--)
                {
                    if (buttonList[y][i].Image == thisButtonImage)
                        buttonList[y][i].BackColor = Color.LightGreen;
                    else
                        break;
                }

                for (int i = x + 1; i < TABLE_WIDTH; i++)
                {
                    if (buttonList[y][i].Image == thisButtonImage)
                        buttonList[y][i].BackColor = Color.LightGreen;
                    else
                        break;
                }
                buttonList[y][x].BackColor = Color.LightGreen;
                return true;
            }
            return false;


        }
        public bool countVertical(int x, int y)
        {
            Image thisButtonImage = buttonList[y][x].Image;
            int count = 0;
            for (int i = y - 1; i >= 0; i--)
            {
                if (buttonList[i][x].Image == thisButtonImage)
                    count++;
                else
                    break;
            }
            for (int i = y + 1; i < TABLE_HEIGHT; i++)
            {
                if (buttonList[i][x].Image == thisButtonImage)
                    count++;
                else
                    break;
            }
            if (count >= 4)
            {
                for (int i = y - 1; i >= 0; i--)
                {
                    if (buttonList[i][x].Image == thisButtonImage)
                        buttonList[i][x].BackColor = Color.LightGreen;
                    else
                        break;
                }
                for (int i = y + 1; i < TABLE_HEIGHT; i++)
                {
                    if (buttonList[i][x].Image == thisButtonImage)
                        buttonList[i][x].BackColor = Color.LightGreen;
                    else
                        break;
                }
                buttonList[y][x].BackColor = Color.LightGreen;
                return true;
            }

            return false;

        }
        public bool countMainDiag(int x, int y)
        {
            Image thisButtonImage = buttonList[y][x].Image;
            int count = 0;
            for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (buttonList[j][i].Image == thisButtonImage)
                    count++;
                else break;
            }
            for (int i = x + 1, j = y + 1; i < TABLE_WIDTH && j < TABLE_HEIGHT; i++, j++)
            {
                if (buttonList[j][i].Image == thisButtonImage)
                    count++;
                else break;
            }

            if (count >= 4)
            {
                for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
                {
                    if (buttonList[j][i].Image == thisButtonImage)
                        buttonList[j][i].BackColor = Color.LightGreen;
                    else break;
                }
                for (int i = x + 1, j = y + 1; i < TABLE_WIDTH && j < TABLE_HEIGHT; i++, j++)
                {
                    if (buttonList[j][i].Image == thisButtonImage)
                        buttonList[j][i].BackColor = Color.LightGreen;
                    else break;
                }
                buttonList[y][x].BackColor = Color.LightGreen;
                return true;
            }
            return false;
        }

        public bool countSubDiag(int x, int y)
        {
            Image thisButtonImage = buttonList[y][x].Image;
            int count = 0;
            for (int i = x - 1, j = y + 1; i >= 0 && j < TABLE_HEIGHT; i--, j++)
            {
                if (buttonList[j][i].Image == thisButtonImage)
                    count++;
                else
                    break;
            }
            for (int i = x + 1, j = y - 1; i < TABLE_WIDTH && j >= 0; i++, j--)
            {
                if (buttonList[j][i].Image == thisButtonImage)
                    count++;
                else
                    break;
            }
            if (count >= 4)
            {
                for (int i = x - 1, j = y + 1; i >= 0 && j < TABLE_HEIGHT; i--, j++)
                {
                    if (buttonList[j][i].Image == thisButtonImage)
                        buttonList[j][i].BackColor = Color.LightGreen;
                    else
                        break;
                }
                for (int i = x + 1, j = y - 1; i < TABLE_WIDTH && j >= 0; i++, j--)
                {
                    if (buttonList[j][i].Image == thisButtonImage)
                        buttonList[j][i].BackColor = Color.LightGreen;
                    else
                        break;
                }
                buttonList[y][x].BackColor = Color.LightGreen;
                return true;
            }
            return false;
        }
        #endregion







        #region Hiệu ứng khởi tạo button
        /// <summary>
        /// Đổi màu border cho button một cách random và xóa nước cờ
        /// </summary>
        /// <param name="color"></param>
        /// <param name="clearBorderColor"></param>
        /// <param name="interval "></param>
        public void UpdateColor(Color color, bool clearBorderColor = false, int interval = 100)
        {
            button_IsLoading = true;

            if (clearBorderColor)
                UpdateColor(backColorNormal);
            ResetTag();
            Random rand = new Random();
            int i = 0;
            while (!IsUpdated())
            {
                for (int j = 0; j < 5; j++)
                {
                    int x = rand.Next(TABLE_WIDTH);
                    int y = rand.Next(TABLE_HEIGHT);
                    buttonList[y][x].FlatAppearance.BorderColor = color;
                    buttonList[y][x].BackColor = backColorNormal;//Trùng ResetColor
                    buttonList[y][x].Tag = 1;
                    buttonList[y][x].Image = null;
                }
                i++;
                if (i < interval)
                    Thread.Sleep(1);
            }
            button_IsLoading = false;

        }

        /// <summary>
        /// Kiểm tra xem tất cả các button có được đổi màu hay chưa
        /// </summary>
        /// <returns></returns>
        public bool IsUpdated()
        {
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    if (buttonList[y][x].Tag.ToString().Equals("0"))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Đặt trạng thái của button thành chưa đổi màu
        /// </summary>
        /// <returns></returns>
        public bool ResetTag()
        {
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    buttonList[y][x].Tag = 0;
                }
            }
            return true;
        }

        /// <summary>
        /// Hiển thị màu button tối hơn (Hiển thị khi pnPause xuất hiện)
        /// </summary>
        /// <returns></returns>
        public void DarkColor()
        {
            button_IsLoading = true;
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    buttonList[y][x].FlatAppearance.BorderColor = Color.FromArgb(69, 69, 69);
                    buttonList[y][x].BackColor = backColorDark;
                    if (buttonList[y][x].Image == PlayerList[1].Image)
                        buttonList[y][x].Image = PlayerList[1].DarkImage;
                    else if (buttonList[y][x].Image == PlayerList[0].Image)
                        buttonList[y][x].Image = PlayerList[0].DarkImage;


                }
            }
            button_IsLoading = false;
        }

        /// <summary>
        /// Đặt lại màu cho button ô cờ tuần tự (dùng khi resume)
        /// </summary>
        public void ResetColor()
        {
            button_IsLoading = true;
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    buttonList[y][x].FlatAppearance.BorderColor = Color.Silver;
                    buttonList[y][x].BackColor = backColorNormal;  //Cần trùng màu với Update Color
                    if (buttonList[y][x].Image == PlayerList[1].DarkImage)
                        buttonList[y][x].Image = PlayerList[1].Image;
                    else if (buttonList[y][x].Image == PlayerList[0].DarkImage)
                        buttonList[y][x].Image = PlayerList[0].Image;
                }
            }
            button_IsLoading = false;
        }

        /// <summary>
        /// Reset bàn cờ
        /// </summary>
        public void Restart(int setRemain)
        {
            remainingTimeInSeconds = setRemain;
            lbTimer.Text = SecondToMinute(remainingTimeInSeconds.ToString());
            isEndGame = false;
            Task.Run(() =>
           {
               UpdateColor(borderColorNormal, true, 50);
           });
            SwitchPlayer();
        }


        public void RandomPatern()
        {
            button_IsLoading = true;
            ResetTag();
            Random rand = new Random();
            for (int i = 0; !IsUpdated(); i++)
            {

                for (int j = 0; j < 5; j++)
                {
                    int x = rand.Next(TABLE_WIDTH);
                    int y = rand.Next(TABLE_HEIGHT);
                    buttonList[y][x].Tag = 1;
                    int temp = rand.Next(3);
                    if (temp == 2)
                        buttonList[y][x].Image = null;
                    else
                        buttonList[y][x].Image = PlayerList[temp].Image;

                }
            }
            button_IsLoading = false;
        }
        #endregion

        #region Timer
        public void StartTimer()
        {
            caro1.Invoke((MethodInvoker)delegate
            {
                timer.Start();
            });

        }

        public void StopTimer()
        {
            caro1.Invoke((MethodInvoker)delegate
            {
                timer.Stop();
            });

        }
        #endregion

        public static string SecondToMinute(string second)
        {
            int minute = int.Parse(second) / 60;
            int second_ = int.Parse(second) % 60;
            string second__ = (second_ == 0) ? "00" : second;
            return minute + ":" + second__;
        }
    }
}


