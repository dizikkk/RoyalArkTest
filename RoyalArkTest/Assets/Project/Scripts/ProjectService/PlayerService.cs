using RoyalArkTest.Interfaces;
using RoyalArkTest.Resource;
using Zenject;

namespace RoyalArkTest
{
    public class PlayerService : IPlayerService
    {
        private DiContainer diContainer;
        
        public PlayerService(DiContainer diContainer) => this.diContainer = diContainer;
        
        public void AddResource(IResource resource, int count)
        {
            IPlayer player = diContainer.Resolve<IPlayer>();
            player.AddResource(resource, count);
        }
    }
}