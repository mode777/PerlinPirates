namespace WorldServer.ValueObjects 
{
    public class Player : GameObject
    {
        public Player()
        {
        }

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int Px { get; set; }
        public int Py { get; set; }
    }

}