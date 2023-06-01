using Lab_3;
using System.Collections.Generic;

namespace LAN_Caro
{
    public class TableManager
    {
        public int isClientPlayer = 1;
        private int isClientTurn;
        public static int SQUARE_SIZE = 40;
        public static int TABLE_WIDTH = 24;
        public static int TABLE_HEIGHT = 16;
        private Addon_Round_Panel table;
        private Label label;
        private PictureBox picture;
        Addon_Round_Panel panel;
        public List<Player> PlayerList { get; set; }
        public List<List<Addon_Custom_Button>> buttonList = new List<List<Addon_Custom_Button>>();

        public TableManager(Addon_Round_Panel table, Label label, PictureBox picture)
        {
            panel = table;
            this.label = label;
            this.picture = picture;
            PlayerList = new List<Player>()
            {
                new Player("X", Properties.Resources.x),
                new Player("O", Properties.Resources.o),
            };
            isClientTurn = 0;
        }



        public void DrawTable()
        {
            Button lastButton = new Button() { Width = 0, Location = new Point(40, 40) };
            for (int i = 0; i < TABLE_HEIGHT; i++)
            {
                buttonList.Add(new List<Addon_Custom_Button>());
                for (int j = 0; j < TABLE_WIDTH; j++)
                {
                    Addon_Custom_Button button = new Addon_Custom_Button()
                    {
                        BackColor = Color.White,
                        BackgroundColor = Color.White,
                        BorderColor = Color.White,
                        BorderRadius = 0,
                        BorderSize = 1,
                        FlatStyle = FlatStyle.Flat,
                        ForeColor = Color.White,
                        Width = SQUARE_SIZE,
                        Height = SQUARE_SIZE,
                        Location = new Point(lastButton.Location.X + lastButton.Width, lastButton.Location.Y),
                        Name = "bt" + j + "_" + i,

                    };
                    button.FlatAppearance.BorderColor = Color.Silver;
                    button.Click += btn_Click;
                    panel.Controls.Add(button);
                    buttonList[i].Add(button);
                    lastButton = button;
                }
                lastButton.Location = new Point(40, lastButton.Location.Y + SQUARE_SIZE);
                lastButton.Width = 0;
                lastButton.Height = 0;
            }
            //MessageBox.Show("sadad");

        }
        public event EventHandler<string> tableButtonClickedSend; //Gửi dữ liệu sang form
        public void btn_Click(object sender, EventArgs e)
        {
            if (isClientPlayer != isClientTurn)  //Nếu chưa tới lượt thì không thể nhấn nút
                return;
            Button button = sender as Button;
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
            if (buttonList[y][x].Image != null)
                return;
            buttonList[y][x].Image = PlayerList[isClientTurn].Image;

            if (countVertical(x, y) >= 4 || countHorizontal(x, y) >= 4 || countMainDiag(x, y) >= 4 || countSubDiag(x, y) >= 4)
                MessageBox.Show("LOOOOOOOSER");
            switchPlayer();
        }




        public void setPlayer(int isClientPlayer)
        {
            this.isClientPlayer = isClientPlayer;
        }

        public void switchPlayer()
        {
            isClientTurn = isClientTurn == 0 ? 1 : 0;
            picture.Image = PlayerList[isClientTurn].Image;
        }

        #region COUNT
        public int countVertical(int x, int y)
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
            return count;


        }
        public int countHorizontal(int x, int y)
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
            return count;
        }
        #endregion

        #region Hiệu ứng khởi tạo button
        public void UpdateCorlor(Color color, int loop = 100)
        {
            resetTag();
            Random rand = new Random();
            int i = 0;
            while (!isUpdated())
            {
                for (int j = 0; j < 5; j++)
                {
                    int x = rand.Next(24);
                    int y = rand.Next(16);
                    buttonList[y][x].BorderColor = color;
                    buttonList[y][x].Tag = 1;
                    buttonList[y][x].Image = null;
                }
                i++;
                if (i < loop)
                    Thread.Sleep(1);
            }
        }


        public bool isUpdated()
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

        public bool resetTag()
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

        public void newGame()
        {
            Task.Run(() =>
            {
                UpdateCorlor(Color.White, 50);
                UpdateCorlor(Color.LightGreen, 50);
            });
            switchPlayer();
        }

        #endregion



        #region Hiệu ứng khởi tạo button
        public void UpdateCorlorTest(Color color, int loop = 100)
        {

            Task.Run(() =>
            {
                resetTag();
                Random rand = new Random();
                int i = 0;
                while (!isUpdated())
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int x = rand.Next(24);
                        int y = rand.Next(16);
                        buttonList[y][x].BorderColor = color;
                        buttonList[y][x].Tag = 1;
                        int temp = rand.Next(3);
                        if (temp == 2)
                            buttonList[y][x].Image = null;
                        else
                            buttonList[y][x].Image = PlayerList[temp].Image;

                    }
                    i++;
                }

            });
            
        }
        #endregion


    }
}

