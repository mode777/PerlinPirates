using System.Drawing;

namespace ExampleGame.Components
{
    public class MovementComponent
    {
        public MovementComponent(int x, int y)
        {
            Value = new Point(x, y);
        }

        public Point Value { get; set; }
    }
}