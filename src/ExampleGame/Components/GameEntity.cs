namespace ExampleGame.Components
{
    public struct GameEntity
    {
        public readonly int Id;
        public readonly EntityType Type;
        public int X;
        public int Y;

        public GameEntity(int id, EntityType type, int x, int y)
        {
            Id = id;
            Type = type;
            X = x;
            Y = y;
        }
    }
}