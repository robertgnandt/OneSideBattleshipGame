using System;

namespace Battleship.App.Models
{
    public class Coordinate
    {
        public readonly int X;
        public readonly int Y;

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Coordinate c))
            {
                return false;
            }

            return c.X == this.X &
                   c.Y == this.Y;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(X, Y).GetHashCode();
        }
    }
}
