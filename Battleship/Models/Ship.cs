namespace Battleship.App.Models
{
    public class Ship
    {
        public Coordinate[] Coordinates { get; set; }

        public bool IsHorizontal;

        public int ShipSize;

        public int Life;

        public Ship(int size, bool isHorizontal)
        {
            this.Coordinates = new Coordinate[size];
            this.ShipSize = size;
            this.IsHorizontal = isHorizontal;
            this.Life = size;
        }
    }
}
