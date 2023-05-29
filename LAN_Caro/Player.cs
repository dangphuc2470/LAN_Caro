namespace LAN_Caro
{
    public class Player
    {
        private string name;
        public string Name { get => name; set => name = value; }
        private Image image;
        public Image Image { get => image; set => image = value; }

        public Player(string name, Image image) 
        {
            Name = name;
            Image = image;
        }



    }
}
