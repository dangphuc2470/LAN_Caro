using Lab_3;

namespace LAN_Caro
{
    public class TableManager
    {
        public int isServerPlayer;
        private int isClientTurn;
        public static int SQUARE_SIZE = 40;
        public static int TABLE_WIDTH = 24;
        public static int TABLE_HEIGHT = 16;
        private Addon_Round_Panel table;
        private Label label;
        private PictureBox picture;
        Addon_Round_Panel Table;
        public List<Player> PlayerList { get; set; }
        public List<List<Button>> buttonList = new List<List<Button>>();

        public TableManager(Addon_Round_Panel table, Label label, PictureBox picture)
        {
            Table = table;
            this.label = label;
            this.picture = picture;
            PlayerList = new List<Player>()
            {
                new Player("X", Properties.Resources.x),
                new Player("O", Properties.Resources.o)
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
                        Width = SQUARE_SIZE,
                        Height = SQUARE_SIZE,
                        Location = new Point(lastButton.Location.X + lastButton.Width, lastButton.Location.Y),
                        FlatStyle = FlatStyle.Flat,
                        Name = "bt" + j + "_" + i,
                    };
                    button.FlatAppearance.BorderColor = Color.Silver;
                    button.Click += btn_Click;
                    Table.Controls.Add(button);
                    buttonList[i].Add(button);
                    lastButton = button;
                }
                lastButton.Location = new Point(40, lastButton.Location.Y + SQUARE_SIZE);
                lastButton.Width = 0;
                lastButton.Height = 0;
            }

        }

        public void btn_Click(object sender, EventArgs e)
        {
            if (isServerPlayer == isClientTurn)  //Nếu chưa tới lượt thì không thể nhấn nút
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
            ButtonClicked?.Invoke(this, x + ":" + y);
        }

        public void clickReceive(int x, int y)
        {
            if (buttonList[y][x].Image != null)
                return;
            buttonList[y][x].Image = PlayerList[isClientTurn].Image;

            if (countVertical(x, y) >= 4 || countHorizontal(x, y) >= 4 || countMainDiag(x, y) >= 4 || countSubDiag(x, y) >= 4)
                MessageBox.Show("WIN");
            switchPlayer();
        }

        public event EventHandler<string> ButtonClicked; //Gửi dữ liệu sang form


        public void setPlayer(int isServerPlayer)
        {
            this.isServerPlayer = isServerPlayer;
        }

        public void switchPlayer()
        {
            if (isClientTurn == 0)
                isClientTurn = 1;
            else
                isClientTurn = 0;
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




    }
}

