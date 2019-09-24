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

        public Game(IGameBpo gameBpo)
        {
            _gameBpo = gameBpo;
        }

        public void StartGame()
        {
            _gameBpo.PlaceShipRandomly(5);
            _gameBpo.PlaceShipRandomly(4);
            _gameBpo.PlaceShipRandomly(4);

            if (System.Diagnostics.Debugger.IsAttached)
            {
                _gameBpo.DisplayGame(true);
            }

            Console.WriteLine("All ships were placed successfully! Let's start the GAME...");

            bool allShipAreSunk;
            do
            {
                var shotStatus = _gameBpo.Shot(GetShotCoordinates());
                Console.WriteLine($"Shot: {shotStatus}");

                _gameBpo.DisplayGame();
                allShipAreSunk = !_gameBpo.PlayerBoard.Ships.Any(s => s.Life > 0);

                if (allShipAreSunk) continue;

                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            } while (!allShipAreSunk);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You WON!!!!");
            Console.ResetColor();
            _gameBpo.DisplayGame(true);
            Console.ReadKey();
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
