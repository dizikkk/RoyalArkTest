using Zenject;

namespace RoyalArkTest
{
    public class GameFactory : IGameFactory
    {
        private ILevelFactory levelFactory;
        private IPlayerFactory playerFactory;
        private IUIFactory uiFactory;
        private ICameraFactory cameraFactory;
        
        [Inject]
        public GameFactory(
            ILevelFactory levelFactory, 
            IPlayerFactory playerFactory,
            IUIFactory uiFactory,
            ICameraFactory cameraFactory)
        {
            this.levelFactory = levelFactory;
            this.playerFactory = playerFactory; 
            this.uiFactory = uiFactory;
            this.cameraFactory = cameraFactory; 
        }

        public void CreateGameplayEntities()
        {
            CreateLevel();
            CreateCamera();
            CreatePlayer();
        }

        private void CreatePlayer() => playerFactory.Create();

        public void CreateUI() => uiFactory.Create();
        
        private void CreateLevel() => levelFactory.CreateLevel();
        private void CreateCamera() => cameraFactory.Create();
    }
}