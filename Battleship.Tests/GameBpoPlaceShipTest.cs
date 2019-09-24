using System.Collections.Generic;
using Battleship.App.BusinessLogic;
using Battleship.App.Enumerations;
using Battleship.App.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests
{
    [TestClass]
    public class GameBpoPlaceShipTest
    {
        //todo: Add test for all Placement Status 

        [TestMethod]
        public void PlaceShipOnBoard_ValidFirstShipCoordinate_NotEnoughPlace()
        {
            var game = CreateTestGame();

            var result = game.PlaceShipOnBoard(new Ship(4, false), new Coordinate(1, 1));

            Assert.AreEqual(PlaceShipStatus.Overlap, result);
        }

        private static GameBpo CreateTestGame()
        {
            var game = new GameBpo
            {
                PlayerBoard = new GameBoard
                {
                    Ships = new List<Ship>
                    {
                        new Ship(4, true)
                        {
                            Coordinates = new[]
                            {
                                new Coordinate(2, 1),
                                new Coordinate(2, 2),
                                new Coordinate(2, 3),
                                new Coordinate(2, 4)
                            }
                        }
                    }
                }
            };
            return game;
        }
    }
}
