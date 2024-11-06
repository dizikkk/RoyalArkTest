using RoyalArkTest.Interfaces;
using Zenject;

namespace RoyalArkTest
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly DiContainer diContainer;
        
        public PlayerFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }
        
        public IPlayer Create()
        {
            IPlayer player = diContainer.Instantiate<Player>();
            diContainer.Bind<IPlayer>().To<Player>().AsSingle().NonLazy();
            return player;
        }
    }
}