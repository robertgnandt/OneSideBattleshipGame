using Battleship.App.BusinessLogic;
using Battleship.App.BusinessLogic.Contracts;
using Ninject.Modules;

namespace Battleship.App
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameBpo>().To<GameBpo>();
        }
    }
}
