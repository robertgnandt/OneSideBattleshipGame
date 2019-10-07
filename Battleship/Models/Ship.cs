namespace Battleship.App.Models
{
    public class Ship
    {
        public Coordinate[] Coordinates { get; set; }

        public bool IsHorizontal;

        public int ShipSize;

        private int _life;

        public Ship(int size, bool isHorizontal)
        {
            this.Coordinates = new Coordinate[size];
            this.ShipSize = size;
            this.IsHorizontal = isHorizontal;
            _life = size;
        }

        public bool IsSunk()
        {
            return _life == 0;
        }

        public void WasShot()
        {
            _life--;
        }
    }
}
