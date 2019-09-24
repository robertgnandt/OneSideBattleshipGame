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

            game.StartGame();
        }

        private static IGameBpo GetIGameBpo()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel.Get<IGameBpo>();
        }
    }
}
