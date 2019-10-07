using Battleship.App;
using Battleship.App.BusinessLogic;
using Battleship.App.BusinessLogic.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleship.Tests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void Game_PLaceShips_Ok()
        {
            var gameBpoMock = new Mock<IGameBpo>();
            gameBpoMock.Setup(m => m.PlaceShipRandomly(It.IsAny<int>()));
            var game = new Game(gameBpoMock.Object);

            var result = game.PlaceShips();
            Assert.AreEqual(true, result);
        }
    }
}
