using System;
using System.Linq;
using Battleship.App.BusinessLogic.Contracts;
using Battleship.App.Helpers;
using Battleship.App.Models;

namespace Battleship.App
{
    public class Game
    {
        private readonly IGameBpo _gameBpo;

        private const int SmallShipSize = 4;
        private const int BigShipSize = 5;

        public Game(IGameBpo gameBpo)
        {
            _gameBpo = gameBpo;
        }

        public void StartGame()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                _gameBpo.DisplayGame(true);
            }

            Console.WriteLine("All ships were placed successfully! Let's start the GAME...");

            do
            {
                var shotStatus = _gameBpo.Shot(GetShotCoordinates());
                Console.WriteLine($"Shot: {shotStatus}");

                _gameBpo.DisplayGame();
                if(_gameBpo.AllShipAreSunk()) continue;

                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            } while (!_gameBpo.AllShipAreSunk());

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You WON!!!!");
            Console.ResetColor();
            _gameBpo.DisplayGame(true);
            Console.ReadKey();
        }

        public bool PlaceShips()
        {
            try
            {
                _gameBpo.PlaceShipRandomly(BigShipSize);
                _gameBpo.PlaceShipRandomly(SmallShipSize);
                _gameBpo.PlaceShipRandomly(SmallShipSize);
            }
            catch
            {
                // log the error
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get the Shot coordinates from user, if the coordinate it's invalid, request a new one
        /// </summary>
        /// <returns>The Shit coordinate</returns>
        private static Coordinate GetShotCoordinates()
        {
            while (true)
            {
                Console.Write("Shot location? ");
                var userChoice = Console.ReadLine();

                if (userChoice == null || userChoice.Trim().Length <= 1) continue;

                var y = Convert.ToChar(userChoice.ToUpper().Substring(0, 1)) - GameHelper.FirstLetterAscii + 1;

                if (y <= 0 || !int.TryParse(userChoice.Substring(1), out var x)) continue;

                return new Coordinate(x, y);
            }
        }
    }
}
