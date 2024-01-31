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
        public static int SCALE100_BUTTON_SIZE = 26;
        public static int SQUARE_SIZE;
        public static int TABLE_WIDTH = 37;
        public static int TABLE_HEIGHT = 16;
        private bool isEndGame = false;
        private int number;

        public CaroOffline()
        {
            InitializeComponent();
            Graphics graphics = CreateGraphics();
            float dpiX = graphics.DpiX;
            SQUARE_SIZE = Convert.ToInt32(SCALE100_BUTTON_SIZE * (dpiX / 96));
            pnTable.Width = SQUARE_SIZE * (TABLE_WIDTH - 1);
            pnTable.Height = SQUARE_SIZE * (TABLE_HEIGHT - 1) + SQUARE_SIZE;
            int xLocation = (this.Width - pnTable.Width - SCALE100_BUTTON_SIZE) / 2;
            pnTable.Location = new System.Drawing.Point(xLocation, pnTable.Location.Y);
            graphics.Dispose();

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
                return;
            }


            if (BotWinMove() == true)
                return;

            #region Kiểm tra người chơi có 4 nước cờ và chặn lại
            if (BotBottomRight(x, y))
                return;
            if (BotTopRight(x, y))
                return;
            if (BotLeft(x, y))
                return;
            #endregion


            if (Bot4Move())
                return;
            if (BlockPlayer4Move())
                return;
            if (Bot3Move())
                return;
            if (BotNearWinMove())
                return;
            if (Bot2Move(number++))
                return;
            //Nếu các nước trên không đi được thì sẽ đi random
            BotRandomMove(x, y);
        }




        /// <summary>
        /// Kiểm tra nếu có nước 4 rồi thì đánh thành 5
        /// </summary>
        /// <returns></returns>
        private bool BotWinMove()
        {
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    if (buttonList[y][x].Tag.ToString() != "0")  //Nếu ô đó đã đánh rồi thì không xử lý nữa
                        continue;
                    if (countVerticalWithTag(x, y, "2", 4) || countHorizontalWithTag(x, y, "2", 4) || countMainDiagWithTag(x, y, "2", 4) || countSubDiagWithTag(x, y, "2", 4))
                    {
                        buttonList[y][x].Image = Properties.Resources.o;
                        buttonList[y][x].Tag = "2";
                        if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
                        {
                            MessageBox.Show("LOSE");
                            isEndGame = true;
                        }

                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra nếu có nước 3 và hai hướng không có nước đi của người chơi thì đánh
        /// </summary>
        /// <returns></returns>
        private bool Bot4Move()
        {
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    if (buttonList[y][x].Tag.ToString() != "0")  //Nếu ô đó đã đánh rồi thì không xử lý nữa
                        continue;
                    if (countVerticalWithTwoFlag(x, y, "2", 3) || countHorizontalWithTwoFlag(x, y, "2", 3) || countMainDiagWithTwoFlag(x, y, "2", 3) || countSubDiagWithTwoFlag(x, y, "2", 3))
                    {
                        buttonList[y][x].Image = Properties.Resources.o;
                        buttonList[y][x].Tag = "2";
                        if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
                        {
                            MessageBox.Show("LOSE");
                            isEndGame = true;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        ///  Kiểm tra người chơi có nước 3 và hai hướng không có nước đi của bot thì đánh
        /// </summary>
        /// <returns></returns>
        private bool BlockPlayer4Move()
        {
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    if (buttonList[y][x].Tag.ToString() != "0")  //Nếu ô đó đã đánh rồi thì không xử lý nữa
                        continue;
                    if (countVerticalWithTwoFlag(x, y, "1", 3) || countHorizontalWithTwoFlag(x, y, "1", 3) || countMainDiagWithTwoFlag(x, y, "1", 3) || countSubDiagWithTwoFlag(x, y, "1", 3))
                    {

                        buttonList[y][x].Image = Properties.Resources.o;
                        buttonList[y][x].Tag = "2";
                        if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
                        {
                            MessageBox.Show("LOSE");
                            isEndGame = true;
                        }
                        return true;
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// Kiểm tra nếu có nước 2 và hai hướng không có nước đi của người chơi thì đánh
        /// </summary>
        /// <returns></returns>
        private bool Bot3Move()
        {
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    if (buttonList[y][x].Tag.ToString() != "0")  //Nếu ô đó đã đánh rồi thì không xử lý nữa
                        continue;
                    if (countVerticalWithTwoFlag(x, y, "2", 2) || countHorizontalWithTwoFlag(x, y, "2", 2) || countMainDiagWithTwoFlag(x, y, "2", 2) || countSubDiagWithTwoFlag(x, y, "2", 2))
                    {
                        buttonList[y][x].Image = Properties.Resources.o;
                        buttonList[y][x].Tag = "2";
                        if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
                        {
                            MessageBox.Show("LOSE");
                            isEndGame = true;
                        }
                        return true;
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// Tìm nước hai hướng không có nước đi của người chơi để đánh
        /// </summary>
        /// <returns></returns>
        private bool Bot2Move(int number)
        {
            if (number % 4 == 0) //Lần lượt tìm nước 2 từ các phía tránh dồn về 1 phía
            {
                //Từ trái qua phải từ trên xuống dưới
                for (int x = 0; x < TABLE_WIDTH; x++)
                {
                    for (int y = 0; y < TABLE_HEIGHT; y++)
                    {
                        if (buttonList[y][x].Tag.ToString() != "0")  //Nếu ô đó đã đánh rồi thì không xử lý nữa
                            continue;
                        if (countVerticalWithTwoFlag(x, y, "2", 1) || countHorizontalWithTwoFlag(x, y, "2", 1) || countMainDiagWithTwoFlag(x, y, "2", 1) || countSubDiagWithTwoFlag(x, y, "2", 1))
                        {
                            buttonList[y][x].Image = Properties.Resources.o;
                            buttonList[y][x].Tag = "2";
                            if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
                            {
                                MessageBox.Show("LOSE");
                                isEndGame = true;
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
            else if (number % 4 == 1)  //Lần lượt tìm nước 2 từ các phía tránh dồn về 1 phía
            {
                //Từ trái qua phải từ dưới lên trên
                for (int x = 0; x < TABLE_WIDTH; x++)
                {
                    for (int y = TABLE_HEIGHT - 1; y >= 0; y--)
                    {
                        if (buttonList[y][x].Tag.ToString() != "0")  //Nếu ô đó đã đánh rồi thì không xử lý nữa
                            continue;
                        if (countVerticalWithTwoFlag(x, y, "2", 1) || countHorizontalWithTwoFlag(x, y, "2", 1) || countMainDiagWithTwoFlag(x, y, "2", 1) || countSubDiagWithTwoFlag(x, y, "2", 1))
                        {
                            buttonList[y][x].Image = Properties.Resources.o;
                            buttonList[y][x].Tag = "2";
                            if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
                            {
                                MessageBox.Show("LOSE");
                                isEndGame = true;
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
            else if (number % 4 == 2)  //Lần lượt tìm nước 2 từ các phía tránh dồn về 1 phía
            {
                //Từ phải qua trái từ dưới lên trên
                for (int x = TABLE_WIDTH - 1; x >= 0; x--)
                {
                    for (int y = TABLE_HEIGHT - 1; y >= 0; y--)
                    {
                        if (buttonList[y][x].Tag.ToString() != "0")  //Nếu ô đó đã đánh rồi thì không xử lý nữa
                            continue;
                        if (countVerticalWithTwoFlag(x, y, "2", 1) || countHorizontalWithTwoFlag(x, y, "2", 1) || countMainDiagWithTwoFlag(x, y, "2", 1) || countSubDiagWithTwoFlag(x, y, "2", 1))
                        {
                            buttonList[y][x].Image = Properties.Resources.o;
                            buttonList[y][x].Tag = "2";
                            if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
                            {
                                MessageBox.Show("LOSE");
                                isEndGame = true;
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                //Từ phải qua trái từ trên xuống dưới
                for (int x = 0; x < TABLE_WIDTH; x++)
                {
                    for (int y = TABLE_HEIGHT - 1; y >= 0; y--)
                    {
                        if (buttonList[y][x].Tag.ToString() != "0")  //Nếu ô đó đã đánh rồi thì không xử lý nữa
                            continue;
                        if (countVerticalWithTwoFlag(x, y, "2", 1) || countHorizontalWithTwoFlag(x, y, "2", 1) || countMainDiagWithTwoFlag(x, y, "2", 1) || countSubDiagWithTwoFlag(x, y, "2", 1))
                        {
                            buttonList[y][x].Image = Properties.Resources.o;
                            buttonList[y][x].Tag = "2";
                            if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
                            {
                                MessageBox.Show("LOSE");
                                isEndGame = true;
                            }
                            return true;
                        }
                    }
                }
                return false;
            }

        }

        /// <summary>
        /// Kiểm tra nếu có nước 3 rồi thì đánh thành 4
        /// </summary>
        /// <returns></returns>
        private bool BotNearWinMove()
        {
            for (int x = 0; x < TABLE_WIDTH; x++)
            {
                for (int y = 0; y < TABLE_HEIGHT; y++)
                {
                    if (buttonList[y][x].Tag.ToString() != "0")  //Nếu ô đó đã đánh rồi thì không xử lý nữa
                        continue;
                    if (countVerticalWithTag(x, y, "2", 3) || countHorizontalWithTag(x, y, "2", 3) || countMainDiagWithTag(x, y, "2", 3) || countSubDiagWithTag(x, y, "2", 3))
                    {
                        buttonList[y][x].Image = Properties.Resources.o;
                        buttonList[y][x].Tag = "2";
                        if (countVertical(x, y) || countHorizontal(x, y) || countMainDiag(x, y) || countSubDiag(x, y))
                        {
                            MessageBox.Show("LOSE");
                            isEndGame = true;
                        }

                        return true;
                    }
                }
            }
            return false;
        }

        private void BotRandomMove(int x, int y)
        {
            Random random = new Random();
            Random random1 = new Random();
            int space = 1;
            while (true)
            {
                int i = random.Next(-space, space + 1);
                while (true)
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
                        if (countVertical(x + i, y + j) || countHorizontal(x + i, y + j) || countMainDiag(x + i, y + j) || countSubDiag(x + i, y + j))
                        {
                            MessageBox.Show("LOSE");
                            isEndGame = true;

                        }
                        return;
                    }
                    space++;
                    if (space > 10) ;
                    {
                        space = 0; break;
                    }
                }
                space++;
            }
        }

        private bool BotLeft(int x, int y)
        {
            for (int i = x - 1; i > 0; i--)
            {
                for (int j = 0; j < TABLE_HEIGHT; j++)
                {
                    if (buttonList[j][i].Tag.ToString() == "0")
                    {
                        //Tìm tất cả nước đi của player có thể thắng
                        if (countVerticalWithTag(i, j, "1", 4) || countHorizontalWithTag(i, j, "1", 4) || countMainDiagWithTag(i, j, "1", 4) || countSubDiagWithTag(i, j, "1", 4))
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
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        private bool BotTopRight(int x, int y)
        {
            for (int i = x; i < TABLE_WIDTH; i++)
            {
                for (int j = y; j > 0; j--)
                {
                    if (buttonList[j][i].Tag.ToString() == "0")
                    {
                        //Tìm tất cả nước đi của player có thể thắng
                        if (countVerticalWithTag(i, j, "1", 4) || countHorizontalWithTag(i, j, "1", 4) || countMainDiagWithTag(i, j, "1", 4) || countSubDiagWithTag(i, j, "1", 4))
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
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool BotBottomRight(int x, int y)
        {
            for (int i = x; i < TABLE_WIDTH; i++)
            {
                for (int j = y; j < TABLE_HEIGHT; j++)
                {
                    if (buttonList[j][i].Tag.ToString() == "0")
                    {
                        //Tìm tất cả nước đi của player có thể thắng
                        if (countVerticalWithTag(i, j, "1", 4) || countHorizontalWithTag(i, j, "1", 4) || countMainDiagWithTag(i, j, "1", 4) || countSubDiagWithTag(i, j, "1", 4))
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
                            return true;
                        }
                    }
                }
            }
            return false;
        }








        #region EndGame
        public bool countHorizontal(int x, int y)
        {
            string thisButtonTag = buttonList[y][x].Tag.ToString();
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
        public bool countHorizontalWithTag(int x, int y, string thisButtonTag, int maxConsecutive)
        {


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
            if (count >= maxConsecutive)
                return true;

            return false;


        }
        public bool countVerticalWithTag(int x, int y, string thisButtonTag, int maxConsecutive)
        {


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
            if (count >= maxConsecutive)


                return true;

            return false;

        }
        public bool countMainDiagWithTag(int x, int y, string thisButtonTag, int maxConsecutive)
        {


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

            if (count >= maxConsecutive)


                return true;

            return false;
        }

        public bool countSubDiagWithTag(int x, int y, string thisButtonTag, int maxConsecutive)
        {
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
            if (count >= maxConsecutive)


                return true;

            return false;
        }



        #endregion

        #region BotTatic
        public bool countHorizontalWithTwoFlag(int x, int y, string thisButtonTag, int maxConsecutive)
        {
            bool flag1 = false;
            bool flag2 = false;


            int count = 0;
            for (int i = x - 1; i >= 0; i--)
            {
                if (buttonList[y][i].Tag.ToString() == thisButtonTag)
                    count++;
                else if (buttonList[y][i].Tag.ToString() == "0")
                {
                    //Kiểm tra xem ô đó còn trống không, nếu trống thì bật flag lên
                    flag1 = true;
                    break;
                }
                else
                    break;

            }

            for (int i = x + 1; i < TABLE_WIDTH; i++)
            {
                if (buttonList[y][i].Tag.ToString() == thisButtonTag)
                    count++;
                else if (buttonList[y][i].Tag.ToString() == "0")
                {
                    //Kiểm tra xem ô đó còn trống không, nếu trống thì bật flag lên
                    flag2 = true;
                    break;
                }
                else
                    break;
            }
            if (count >= maxConsecutive && (flag1 == true && flag2 == true))
                return true;

            return false;


        }
        public bool countVerticalWithTwoFlag(int x, int y, string thisButtonTag, int maxConsecutive)
        {
            bool flag1 = false;
            bool flag2 = false;
            int count = 0;
            for (int i = y - 1; i >= 0; i--)
            {
                if (buttonList[i][x].Tag.ToString() == thisButtonTag)
                    count++;
                else if (buttonList[i][x].Tag.ToString() == "0")
                {
                    //Kiểm tra xem ô đó còn trống không, nếu trống thì bật flag lên
                    flag1 = true;
                    break;
                }
                else
                    break;
            }
            for (int i = y + 1; i < TABLE_HEIGHT; i++)
            {
                if (buttonList[i][x].Tag.ToString() == thisButtonTag)
                    count++;
                else if (buttonList[i][x].Tag.ToString() == "0")
                {
                    //Kiểm tra xem ô đó còn trống không, nếu trống thì bật flag lên
                    flag2 = true;
                    break;
                }
                else
                    break;
            }
            if (count >= maxConsecutive && (flag1 == true && flag2 == true))
                return true;

            return false;

        }
        public bool countMainDiagWithTwoFlag(int x, int y, string thisButtonTag, int maxConsecutive)
        {
            bool flag1 = false;
            bool flag2 = false;


            int count = 0;
            for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else if (buttonList[j][i].Tag.ToString() == "0")
                {
                    //Kiểm tra xem ô đó còn trống không, nếu trống thì bật flag lên
                    flag1 = true;
                    break;
                }
                else break;
            }
            for (int i = x + 1, j = y + 1; i < TABLE_WIDTH && j < TABLE_HEIGHT; i++, j++)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else if (buttonList[j][i].Tag.ToString() == "0")
                {
                    //Kiểm tra xem ô đó còn trống không, nếu trống thì bật flag lên
                    flag2 = true;
                    break;
                }
                else break;
            }

            if (count >= maxConsecutive && (flag1 == true && flag2 == true))
                return true;

            return false;
        }

        public bool countSubDiagWithTwoFlag(int x, int y, string thisButtonTag, int maxConsecutive)
        {
            bool flag1 = false;
            bool flag2 = false;


            int count = 0;
            for (int i = x - 1, j = y + 1; i >= 0 && j < TABLE_HEIGHT; i--, j++)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else if (buttonList[j][i].Tag.ToString() == "0")
                {
                    //Kiểm tra xem ô đó còn trống không, nếu trống thì bật flag lên
                    flag1 = true;
                    break;
                }
                else
                    break;
            }
            for (int i = x + 1, j = y - 1; i < TABLE_WIDTH && j >= 0; i++, j--)
            {
                if (buttonList[j][i].Tag.ToString() == thisButtonTag)
                    count++;
                else if (buttonList[j][i].Tag.ToString() == "0")
                {
                    //Kiểm tra xem ô đó còn trống không, nếu trống thì bật flag lên
                    flag2 = true;
                    break;
                }
                else
                    break;
            }
            if (count >= maxConsecutive && (flag1 == true && flag2 == true))
                return true;

            return false;
        }

        #endregion



        /// <summary>
        /// Restart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btHost_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
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
            while (i < 2000)
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

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
