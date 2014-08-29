using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PicBoxTest
{
    public class Tile
    {
        public Direction Direction { get; set; }
        public int ID { get; set; }
        public int TravelDistance { get; set; }
        public Point Location { get; set; }
        public Tile(int ID, Point location)
        {
            this.TravelDistance = 0;
            this.ID = ID;
            this.Location = location;

            //Default, move right.
            this.Direction = Direction.Right;
        }
    }
    public enum Direction
    {
        Left,
        Right
    }
}
