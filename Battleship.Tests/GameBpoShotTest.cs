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
        [TestMethod]
        public void Shot_InvalidCoordinate_Invalid()
        {
            var game = CreateTestGame();

            var result = game.Shot(new Coordinate(20, 20));

            Assert.AreEqual(ShotStatus.Invalid, result);
        }

        [TestMethod]
        public void Shot_ValidCoordinate_Miss()
        {
            var game = CreateTestGame();

            var result = game.Shot(new Coordinate(3, 3));

            Assert.AreEqual(ShotStatus.Miss, result);
        }

        [TestMethod]
        public void Shot_ValidCoordinate_Hit()
        {
            var game = CreateTestGame();

            var result = game.Shot(new Coordinate(2, 1));

            Assert.AreEqual(ShotStatus.Hit, result);
        }

        [TestMethod]
        public void Shot_ValidCoordinate_Sank()
        {
            var game = CreateTestGame();
            game.Shot(new Coordinate(2, 1));
            game.Shot(new Coordinate(2, 2));
            game.Shot(new Coordinate(2, 3));
            var result = game.Shot(new Coordinate(2, 4));

            Assert.AreEqual(ShotStatus.Sank, result);
        }

        [TestMethod]
        public void Shot_ValidCoordinate_Duplicate()
        {
            var game = CreateTestGame();

            game.Shot(new Coordinate(2, 5));
            var result = game.Shot(new Coordinate(2, 5));

            Assert.AreEqual(ShotStatus.Duplicate, result);
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
