using System;
using System.Linq;
using Battleship.App.BusinessLogic.Contracts;
using Battleship.App.Enumerations;
using Battleship.App.Helpers;
using Battleship.App.Models;

namespace Battleship.App.BusinessLogic
{
    public class GameBpo : IGameBpo
    {
        public GameBoard PlayerBoard { get; set;}

        public GameBpo()
        {
            this.PlayerBoard = new GameBoard();
        }

        public void PlaceShipRandomly(int shipSize)
        {
            PlaceShipStatus result;

            do
            {
                var newShip = new Ship(shipSize, RandomHelper.IsHorizontalPlane());
                var randomCoordinate = new Coordinate(RandomHelper.GetShipCoordinate(this.PlayerBoard.GridDimension),
                    RandomHelper.GetShipCoordinate(this.PlayerBoard.GridDimension));

                result = PlaceShipOnBoard(newShip, randomCoordinate);
            } while (result != PlaceShipStatus.Ok);
        }

        public PlaceShipStatus PlaceShipOnBoard(Ship newShip, Coordinate coordinate)
        {
            // when the Plane is Horizontal we will increase or decrease the X coordinate depending on direction and the Y will remain the same
            var stepX = !newShip.IsHorizontal ? 1 : 0;
            // when the Plane is Vertical we will increase or decrease the Y coordinate and the X will remain the same
            var stepY = newShip.IsHorizontal ? 1 : 0;

            for (var position = 0; position < newShip.ShipSize; position++)
            {
                if (!IsValidCoordinate(coordinate))
                {
                    return PlaceShipStatus.NotEnoughSpace;
                }

                if (InUse(coordinate))
                {
                    return PlaceShipStatus.Overlap;
                }

                newShip.Coordinates[position] = coordinate;
                coordinate = new Coordinate(coordinate.X + stepX, coordinate.Y + stepY);
            }

            this.PlayerBoard.Ships.Add(newShip);
            return PlaceShipStatus.Ok;
        }

        public void DisplayGame(bool displayShips = false)
        {
            for (var x = this.PlayerBoard.GridDimension; x > 0; x--)
            {
                Console.Write(x + (x > 9 ? " " : "  "));
                for (var y = 1; y <= this.PlayerBoard.GridDimension; y++)
                {
                    var coordinate = new Coordinate(x, y);
                    if (displayShips && InUse(coordinate))
                    {
                        Console.Write("S  ");
                    }
                    else
                    {
                        if (!this.PlayerBoard.ShotHistory.ContainsKey(coordinate))
                        {
                            Console.Write(".  ");
                        }
                        else
                        {
                            Console.Write(this.PlayerBoard.ShotHistory[coordinate] == ShotStatus.Miss ? "X  " : "S  ");
                        }
                    }
                }
                Console.WriteLine();
            }

            Console.Write("   ");
            for (var x = 1; x <= this.PlayerBoard.GridDimension; x++)
            {
                var xDirectionText = (char)(GameHelper.FirstLetterAscii + x -1);
                Console.Write($"{xDirectionText}  ");
            }
            Console.WriteLine();
        }

        public ShotStatus Shot(Coordinate coordinate)
        {
            if (!IsValidCoordinate(coordinate))
            {
                return ShotStatus.Invalid;
            }

            if (this.PlayerBoard.ShotHistory.ContainsKey(coordinate))
            {
               return ShotStatus.Duplicate;
            }

            var shotStatus = ShotStatus.Miss;
            var ship = this.PlayerBoard.Ships.FirstOrDefault(x => x.Coordinates.Contains(coordinate));
            if (ship != null)
            {
                ship.WasShot();
                shotStatus = ship.IsSunk() ? ShotStatus.Sank : ShotStatus.Hit;
            }
            this.PlayerBoard.ShotHistory.Add(coordinate, shotStatus);

            return shotStatus;
        }

        public bool AllShipAreSunk()
        {
            return this.PlayerBoard.Ships.All(s => s.IsSunk());
        }

        private bool IsValidCoordinate(Coordinate coordinate)
        {
            return coordinate.X >= 1 && coordinate.X <= this.PlayerBoard.GridDimension &&
                   coordinate.Y >= 1 && coordinate.Y <= this.PlayerBoard.GridDimension;
        }

        private bool InUse(Coordinate coordinate)
        {
            return this.PlayerBoard.Ships.SelectMany(ship => ship.Coordinates).Contains(coordinate);
        }
    }
}