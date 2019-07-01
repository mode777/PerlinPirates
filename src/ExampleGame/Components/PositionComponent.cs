using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ExampleGame.Components
{


    public class PositionComponent
    {
        public PositionComponent(int x, int y)
        {
            Value = new Point(x,y);
        }

        public Point Value { get; set; }
    }
}
