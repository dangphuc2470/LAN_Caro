using System.Collections.Generic;
using System.Windows.Forms;

namespace LAN_Caro
{
    public class TableManager
    {
        public int isClientPlayer = 1;
        private int isClientTurn;
        public static int SQUARE_SIZE = 40;
        public static int TABLE_WIDTH = 24;
        public static int TABLE_HEIGHT = 16;
        public RichTextBox rtbLog;
        public PictureBox imgTurn;
        public TextBox tbIPAdress;
        public Panel pnTable;
        public List<Player> PlayerList { get; set; }
        public List<List<Button>> buttonList = new List<List<Button>>();

        public TableManager(Panel pnTable, RichTextBox rtbLog, PictureBox imgTurn, TextBox tbIPAdress)
        {
            this.pnTable = pnTable;
            this.rtbLog = rtbLog;
            this.imgTurn = imgTurn;
            this.tbIPAdress = tbIPAdress;
            PlayerList = new List<Player>()
            {
                new Player("X", Properties.Resources.x, Properties.Resources.xd),
                new Player("O", Properties.Resources.o, Properties.Resources.od),
            };
            isClientTurn = 0;
        }



        public void DrawTable()
        {
            Button lastButton = new Button() { Width = 0, Location = new Point(40, 40) };
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
                    button.FlatAppearance.BorderColor = Color.White;
                    button.Click += btn_Click;
                    pnTable.Controls.Add(button);
                    buttonList[i].Add(button);
                    lastButton = button;
                }
                lastButton.Location = new Point(40, lastButton.Location.Y + SQUARE_SIZE);
                lastButton.Width = 0;
                lastButton.Height = 0;
            }

        }
        public event EventHandler<string> tableButtonClickedSend; //Gửi dữ liệu sang form
        public void btn_Click(object sender, EventArgs e)
        {
            if (isClientPlayer != isClientTurn)  //Nếu chưa tới lượt thì không thể nhấn nút
                return;
            Button? button = sender as Button;
            int index = button.Name.IndexOf("_");
            int x = Int32.Parse(button.Name.Substring(2, index - 2));
            int y = Int32.Parse(button.Name.Substring(index + 1));
            if (buttonList[y][x].Image != null)
                return;
            buttonList[y][x].Image = PlayerList[isClientTurn].Image;

            if (countVertical(x, y) >= 4 || countHorizontal(x, y) >= 4 || countMainDiag(x, y) >= 4 || countSubDiag(x, y) >= 4)
                MessageBox.Show("WIN");
            tableButtonClickedSend?.Invoke(this, x + ":" + y);
        }

        public void clickReceive(int x, int y)
        {
            //MessageBox.Show(x.ToString() + y.ToString());
            if (buttonList[y][x].Image != null)
                return;
            buttonList[y][x].Image = PlayerList[isClientTurn].Image;

            if (countVertical(x, y) >= 4 || countHorizontal(x, y) >= 4 || countMainDiag(x, y) >= 4 || countSubDiag(x, y) >= 4)
                MessageBox.Show("LOSE");
            SwitchPlayer();
        }




        public void setPlayer(int isClientPlayer)
        {
            this.isClientPlayer = isClientPlayer;
        }

        public void SwitchPlayer()
        {
            isClientTurn = isClientTurn == 0 ? 1 : 0;
            imgTurn.Image = PlayerList[isClientTurn].Image;
        }

        #region COUNT
        public int countHorizontal(int x, int y)
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
            }
            return count;


        }
        public int countVertical(int x, int y)
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
            }

            return count;

        }
        public int countMainDiag(int x, int y)
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
            }
            return count;
        }

        public int countSubDiag(int x, int y)
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
            if (count >=4 ) 
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
            }
            return count;
        }
        #endregion

        #region Hiệu ứng khởi tạo button
        /// <summary>
        /// Đổi màu border cho button và xóa nước cờ
        /// </summary>
        /// <param name="color"></param>
        /// <param name="updateWhite"></param>
        /// <param name="interval"></param>
        public void UpdateColor(Color color, bool updateWhite = false, int interval = 100)
        {
            if (updateWhite)
                UpdateColor(Color.White);
            ResetTag();
            Random rand = new Random();
            int i = 0;
            while (!IsUpdated())
            {
                for (int j = 0; j < 5; j++)
                {
                    int x = rand.Next(24);
                    int y = rand.Next(16);
                    buttonList[y][x].FlatAppearance.BorderColor = color;
                    buttonList[y][x].BackColor = Color.White;
                    buttonList[y][x].Tag = 1;
                    buttonList[y][x].Image = null;
                }
                i++;
                if (i < interval)
                    Thread.Sleep(1);
            }
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
        /// Hiển thị màu button tối hơn
        /// </summary>
        /// <returns></returns>
        public void DarkColor()
        {
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    buttonList[y][x].FlatAppearance.BorderColor = Color.FromArgb(69, 69, 69);
                    buttonList[y][x].BackColor = Color.FromArgb(75, 75, 75);
                    if (buttonList[y][x].Image == PlayerList[1].Image)
                        buttonList[y][x].Image = PlayerList[1].DarkImage;
                    else if (buttonList[y][x].Image == PlayerList[0].Image)
                        buttonList[y][x].Image = PlayerList[0].DarkImage;


                }
            }
        }

        /// <summary>
        /// Đặt lại màu cho button ô cờ
        /// </summary>
        public void ResetColor()
        {
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    buttonList[y][x].FlatAppearance.BorderColor = Color.Silver;
                    buttonList[y][x].BackColor = Color.White;
                    if (buttonList[y][x].Image == PlayerList[1].DarkImage)
                        buttonList[y][x].Image = PlayerList[1].Image;
                    else if (buttonList[y][x].Image == PlayerList[0].DarkImage)
                        buttonList[y][x].Image = PlayerList[0].Image;
                }
            }
        }

        /// <summary>
        /// Reset bàn cờ
        /// </summary>
        public void Restart()
        {
            Task.Run(() =>
            {
                UpdateColor(Color.Silver, true, 50);
            });
            SwitchPlayer();
        }

        #endregion



        #region Test New Game
        public void RandomPatern()
        {


            ResetTag();
            Random rand = new Random();
            int i = 0;
            while (!IsUpdated())
            {
                for (int j = 0; j < 5; j++)
                {
                    int x = rand.Next(24);
                    int y = rand.Next(16);
                    buttonList[y][x].Tag = 1;
                    int temp = rand.Next(3);
                    if (temp == 2)
                        buttonList[y][x].Image = null;
                    else
                        buttonList[y][x].Image = PlayerList[temp].Image;

                }
                i++;
            }



        }
        #endregion


    }
}

