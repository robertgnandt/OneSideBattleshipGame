using System.Collections.Generic;
using Battleship.App.Enumerations;
using Battleship.App.Helpers;

namespace Battleship.App.Models
{
    public class GameBoard
    {
        public int GridDimension;

        public List<Ship> Ships { get; set; }

        public Dictionary<Coordinate, ShotStatus> ShotHistory { get; set; }

        public GameBoard()
        {
            GridDimension = GameHelper.GetGridDimension();
            Ships = new List<Ship>();
            ShotHistory = new Dictionary<Coordinate, ShotStatus>();
        }
    }
}
