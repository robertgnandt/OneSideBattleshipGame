using System;
using System.Reflection;
using Battleship.App.BusinessLogic.Contracts;
using Ninject;

namespace Battleship.App
{
    class Program
    {
        static void Main()
        {
            var game = new Game(GetIGameBpo());
            if (game.PlaceShips())
            {
                game.StartGame();
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again!!!");
                Console.ReadKey();
            }
        }

        private static IGameBpo GetIGameBpo()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel.Get<IGameBpo>();
        }
    }
}
