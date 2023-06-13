using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public static int TABLE_WIDTH = 25;
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
            int i; int j;
            while (space < 10)
            {
                i = random.Next(-space, space + 1);
                j = random1.Next(-space, space + 1);
                if (y + j < 0 || x + i < 0 || y + j >= TABLE_HEIGHT || x + i >= TABLE_WIDTH)
                {
                    space++;
                    continue;
                }

                if (buttonList[y + j][x + i].Tag.ToString() == "0")
                {
                    //Tìm tất cả nước đi của player có thể thắng
                    if (countVertical(x + i, y + j, "1") || countHorizontal(x + i, y + j, "1") || countMainDiag(x + i, y + j, "1") || countSubDiag(x + i, y + j, "1"))
                    {
                        MessageBox.Show("warining");
                        //Khi tìm thấy sẽ đánh vào
                        buttonList[y + j][x + i].Image = Properties.Resources.o;
                        buttonList[y + j][x + i].Tag = "2";
                        //Sau đó kiếm tra thắng thua
                        if (countVertical(x + i, y + j) || countHorizontal(x + i, j + y) || countMainDiag(x + i, y + j) || countSubDiag(x + i, y + j))
                        {
                            MessageBox.Show("LOSE");
                            isEndGame = true;
                        }
                        isCounter = true;
                        break;
                    }
                }
                space++;
            }

            //if (!isCounter) //Nếu không tìm thấy sẽ đánh random
            //{
            //    space = 1;
            //    while (space < 10)
            //    {
            //        i = random.Next(-space, space + 1);
            //        j = random1.Next(-space, space + 1);
            //        if (y + j < 0 || x + i < 0 || y + j >= TABLE_HEIGHT || x + i >= TABLE_WIDTH)
            //        {
            //            space++;
            //            continue;
            //        }

            //        if (buttonList[y + j][x + i].Tag.ToString() == "0")
            //        {
            //            buttonList[y + j][x + i].Image = Properties.Resources.o;
            //            buttonList[y + j][x + i].Tag = "2";
            //            //Sau đó kiếm tra thắng thua
            //            if (countVertical(x + i, y + j) || countHorizontal(x + i, j + y) || countMainDiag(x + i, y + j) || countSubDiag(x + i, y + j))
            //            {
            //                MessageBox.Show("LOSE");
            //                isEndGame = true;
            //            }
            //            break;
            //        }
            //        space++;

            //    }
            //}

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

            if (count >= 2)


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
            if (count >= 2)


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

            if (count >= 2)


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
            if (count >= 2)


                return true;

            return false;
        }
        #endregion
    }
}
