using Battleship.App.Enumerations;
using Battleship.App.Models;

namespace Battleship.App.BusinessLogic.Contracts
{
    public interface IGameBpo
    {
        GameBoard PlayerBoard { get; set; }

        void PlaceShipRandomly(int shipSize);

        /// <summary>
        /// Place the Ship on board if it's possible
        /// </summary>
        /// <param name="newShip">The new ship with dimension and direction</param>
        /// <param name="coordinate">The Ship first coordinate</param>
        /// <returns>Placement status</returns>
        PlaceShipStatus PlaceShipOnBoard(Ship newShip, Coordinate coordinate);

        /// <summary>
        /// Display the shot history
        /// </summary>
        /// <param name="displayShips">Display the ships on the board</param>
        void DisplayGame(bool displayShips = false);

        /// <summary>
        /// Check the coordinates, if it's a Hit the Ship life are decremented / the shot is saved in the history
        /// </summary>
        /// <returns>The shot status</returns>
        ShotStatus Shot(Coordinate coordinate);
    }
}
