using System.Collections.Generic;
using Battleship.App.BusinessLogic;
using Battleship.App.Enumerations;
using Battleship.App.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests
{
    [TestClass]
    public class GameBpoShotTest
    {
        //todo: Add test for all Shot Type

        [TestMethod]
        public void Shot_ValidCoordinate_Hit()
        {
            var game = CreateTestGame();

            var result = game.Shot(new Coordinate(2, 1));

            Assert.AreEqual(ShotStatus.Hit, result);
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
