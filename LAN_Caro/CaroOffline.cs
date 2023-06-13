using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAN_Caro
{
    public partial class CaroOffline : Form
    {
        public List<List<Button>> buttonList = new List<List<Button>>();
        public static int SQUARE_SIZE = 40;
        public static int TABLE_WIDTH = 30;
        public static int TABLE_HEIGHT = 17;
        private bool isEndGame = false;

        public CaroOffline()
        {
            InitializeComponent();
        }

        private void CaroOffline_Load(object sender, EventArgs e)
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
                    button.FlatAppearance.BorderColor = Color.Gainsboro;
                    button.Parent = pnTable;
                    button.BackColor = Color.White;
                    button.Click += btn_Click;
                    button.Tag = "0";
                    pnTable.Controls.Add(button);
                    buttonList[i].Add(button);
                    lastButton = button;
                }
                lastButton.Location = new Point(0, lastButton.Location.Y + SQUARE_SIZE);
                lastButton.Width = 0;
                lastButton.Height = 0;
            }

        }

        private void btn_Click(object? sender, EventArgs e)
        {
            if (isEndGame == true)
                return;
            Button? button = sender as Button;
            int index = button.Name.IndexOf("_");
            int x = Int32.Parse(button.Name.Substring(2, index - 2));
            int y = Int32.Parse(button.Name.Substring(index + 1));
            if (buttonList[y][x].Image != null)
                return;
            buttonList[y][x].Image = Properties.Resources.x;
            buttonList[y][x].Tag = "1";
            if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
            {
                MessageBox.Show("WIN");
                isEndGame = true;
            }

            bool isCounter = false;
            int space = 1;
            Random random = new Random();
            Random random1 = new Random();

            Task.Run(() =>
            {

                //BOTTOM_RIGHT
                if (isEndGame == false)
                {
                    for (int i = x; i < TABLE_WIDTH; i++)
                    {
                        for (int j = y; j < TABLE_HEIGHT; j++)
                        {
                            if (buttonList[j][i].Tag.ToString() == "0")
                            {
                                //Tìm tất cả nước đi của player có thể thắng
                                if (countVertical(i, j, "1") || countHorizontal(i, j, "1") || countMainDiag(i, j, "1") || countSubDiag(i, j, "1"))
                                {
                                    //Khi tìm thấy sẽ đánh vào
                                    buttonList[j][i].Image = Properties.Resources.o;
                                    buttonList[j][i].Tag = "2";
                                    //Sau đó kiếm tra thắng thua
                                    if (countVertical(i, j) || countHorizontal(i, j) || countMainDiag(i, j) || countSubDiag(i, j))
                                    {
                                        MessageBox.Show("LOSE");
                                        isEndGame = true;
                                    }
                                    isCounter = true;
                                    break;
                                }
                            }
                        }
                        if (isCounter)
                            break;
                    }
                }

                //TOP RIGHT
                if (!isCounter && isEndGame == false)
                {
                    for (int i = x; i < TABLE_WIDTH; i++)
                    {
                        for (int j = y; j > 0; j--)
                        {
                            if (buttonList[j][i].Tag.ToString() == "0")
                            {
                                //Tìm tất cả nước đi của player có thể thắng
                                if (countVertical(i, j, "1") || countHorizontal(i, j, "1") || countMainDiag(i, j, "1") || countSubDiag(i, j, "1"))
                                {
                                    //Khi tìm thấy sẽ đánh vào
                                    buttonList[j][i].Image = Properties.Resources.o;
                                    buttonList[j][i].Tag = "2";
                                    //Sau đó kiếm tra thắng thua
                                    if (countVertical(i, j) || countHorizontal(i, j) || countMainDiag(i, j) || countSubDiag(i, j))
                                    {
                                        MessageBox.Show("LOSE");
                                        isEndGame = true;
                                    }
                                    isCounter = true;
                                    break;
                                }
                            }
                        }
                        if (isCounter)
                            break;
                    }

                }


                //LEFT
                if (!isCounter && isEndGame == false)
                {
                    for (int i = x - 1; i > 0; i--)
                    {
                        for (int j = 0; j < TABLE_HEIGHT; j++)
                        {
                            if (buttonList[j][i].Tag.ToString() == "0")
                            {
                                //Tìm tất cả nước đi của player có thể thắng
                                if (countVertical(i, j, "1") || countHorizontal(i, j, "1") || countMainDiag(i, j, "1") || countSubDiag(i, j, "1"))
                                {
                                    //MessageBox.Show("warining");
                                    //Khi tìm thấy sẽ đánh vào
                                    buttonList[j][i].Image = Properties.Resources.o;
                                    buttonList[j][i].Tag = "2";
                                    //Sau đó kiếm tra thắng thua
                                    if (countVertical(i, j) || countHorizontal(i, j) || countMainDiag(i, j) || countSubDiag(i, j))
                                    {
                                        MessageBox.Show("LOSE");
                                        isEndGame = true;
                                    }
                                    isCounter = true;
                                    break;
                                }
                            }
                        }
                        if (isCounter)
                            break;
                    }

                }

                if (!isCounter) //Random
                {
                    int l = 0;
                    while (!isCounter)
                    {
                        int i = random.Next(-space, space + 1);
                        while (!isCounter)
                        {
                            int j = random1.Next(-space, space + 1);
                            if (y + j < 0 || y + j >= TABLE_HEIGHT)
                                continue;
                            if (x + i < 0 || x + i >= TABLE_WIDTH)
                                continue;
                            if (buttonList[y + j][x + i].Tag.ToString() == "0")
                            {
                                buttonList[y + j][x + i].Image = Properties.Resources.o;
                                buttonList[y + j][x + i].Tag = "2";
                                //Sau đó kiếm tra thắng thua
                                if (countVertical(x + i, y + j) || countHorizontal(x + i, y + j) || countMainDiag(x + i, y + j) || countSubDiag(x + i, y + j))
                                {
                                    MessageBox.Show("LOSE");
                                    isEndGame = true;
                                }
                                isCounter = true;
                                break;
                            }
                        }
                    }
                }
            });
        }






        #region EndGame
        public bool countHorizontal(int x, int y)
        {
            string thisButtonTag = buttonList[y][x].Tag.ToString();
            int count = 0;
            for (int i = x - 1; i >= 0; i--)
            {
                //MessageBox.Show(buttonList[y][i].Image.ToString() + thisButtonImage.ToString());
                if (buttonList[y][i].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }

            for (int i = x + 1; i < TABLE_WIDTH; i++)
            {
                if (buttonList[y][i].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }
            // MessageBox.Show(count.ToString());

            if (count >= 4)
            {
                for (int i = x - 1; i >= 0; i--)
                {
                    if (buttonList[y][i].Tag.ToString() == thisButtonTag)
                        buttonList[y][i].BackColor = Color.LightGreen;
                    else
                        break;
                }

                for (int i = x + 1; i < TABLE_WIDTH; i++)
                {
                    if (buttonList[y][i].Tag.ToString() == thisButtonTag)
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
            string thisButtonTag = buttonList[y][x].Tag.ToString();
            int count = 0;
            for (int i = y - 1; i >= 0; i--)
            {
                if (buttonList[i][x].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }
            for (int i = y + 1; i < TABLE_HEIGHT; i++)
            {
                if (buttonList[i][x].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }
            if (count >= 4)
            {
                for (int i = y - 1; i >= 0; i--)
                {
                    if (buttonList[i][x].Tag.ToString() == thisButtonTag)
                        buttonList[i][x].BackColor = Color.LightGreen;
                    else
                        break;
                }
                for (int i = y + 1; i < TABLE_HEIGHT; i++)
                {
                    if (buttonList[i][x].Tag.ToString() == thisButtonTag)
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
            string thisButtonTag = buttonList[y][x].Tag.ToString();
            int count = 0;
            for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else break;
            }
            for (int i = x + 1, j = y + 1; i < TABLE_WIDTH && j < TABLE_HEIGHT; i++, j++)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else break;
            }

            if (count >= 4)
            {
                for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
                {
                    if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                        buttonList[j][i].BackColor = Color.LightGreen;
                    else break;
                }
                for (int i = x + 1, j = y + 1; i < TABLE_WIDTH && j < TABLE_HEIGHT; i++, j++)
                {
                    if (buttonList[j][i].Tag.ToString() == thisButtonTag)
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
            string thisButtonTag = buttonList[y][x].Tag.ToString();
            int count = 0;
            for (int i = x - 1, j = y + 1; i >= 0 && j < TABLE_HEIGHT; i--, j++)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }
            for (int i = x + 1, j = y - 1; i < TABLE_WIDTH && j >= 0; i++, j--)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }
            if (count >= 4)
            {
                for (int i = x - 1, j = y + 1; i >= 0 && j < TABLE_HEIGHT; i--, j++)
                {
                    if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                        buttonList[j][i].BackColor = Color.LightGreen;
                    else
                        break;
                }
                for (int i = x + 1, j = y - 1; i < TABLE_WIDTH && j >= 0; i++, j--)
                {
                    if (buttonList[j][i].Tag.ToString() == thisButtonTag)
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

        #region Bot
        public bool countHorizontal(int x, int y, string thisButtonTag = null)
        {
            if (thisButtonTag == null)
                thisButtonTag = buttonList[y][x].Tag.ToString();
            int count = 0;
            for (int i = x - 1; i >= 0; i--)
            {
                if (buttonList[y][i].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }

            for (int i = x + 1; i < TABLE_WIDTH; i++)
            {
                if (buttonList[y][i].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }
            if (count >= 3)
                return true;

            return false;


        }
        public bool countVertical(int x, int y, string thisButtonTag = null)
        {
            if (thisButtonTag == null)
                thisButtonTag = buttonList[y][x].Tag.ToString();
            int count = 0;
            for (int i = y - 1; i >= 0; i--)
            {
                if (buttonList[i][x].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }
            for (int i = y + 1; i < TABLE_HEIGHT; i++)
            {
                if (buttonList[i][x].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }
            if (count >= 3)


                return true;

            return false;

        }
        public bool countMainDiag(int x, int y, string thisButtonTag = null)
        {
            if (thisButtonTag == null)
                thisButtonTag = buttonList[y][x].Tag.ToString();
            int count = 0;
            for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else break;
            }
            for (int i = x + 1, j = y + 1; i < TABLE_WIDTH && j < TABLE_HEIGHT; i++, j++)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else break;
            }

            if (count >= 3)


                return true;

            return false;
        }

        public bool countSubDiag(int x, int y, string thisButtonTag = null)
        {
            if (thisButtonTag == null)
                thisButtonTag = buttonList[y][x].Tag.ToString();
            int count = 0;
            for (int i = x - 1, j = y + 1; i >= 0 && j < TABLE_HEIGHT; i--, j++)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }
            for (int i = x + 1, j = y - 1; i < TABLE_WIDTH && j >= 0; i++, j--)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else
                    break;
            }
            if (count >= 3)


                return true;

            return false;
        }
        #endregion

        private void btHost_Click(object sender, EventArgs e)
        {
            Task.Run(() => { 
            UpdateColor();
            ResetTag();
            Random rand = new Random();
            int i = 0;
            while (i < 2000)
            {
                i++;
                for (int j = 0; j < 5; j++)
                {
                    int x = rand.Next(TABLE_WIDTH);
                    int y = rand.Next(TABLE_HEIGHT);
                    buttonList[y][x].BackColor = Color.White;
                    buttonList[y][x].Image = null;
                }
                i++;
                if (i < 100)
                    Thread.Sleep(1);
            }
            });
            isEndGame = false;
        }

        private void UpdateColor()
        {
            Random rand = new Random();
            int i = 0;
            while (i<2000)
            {
                i++;
                for (int j = 0; j < 5; j++)
                {
                    int x = rand.Next(TABLE_WIDTH);
                    int y = rand.Next(TABLE_HEIGHT);
                    buttonList[y][x].BackColor = Color.WhiteSmoke;
                    buttonList[y][x].Image = null;
                }
                i++;
                if (i < 100)
                    Thread.Sleep(1);
            }
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
    }
}
