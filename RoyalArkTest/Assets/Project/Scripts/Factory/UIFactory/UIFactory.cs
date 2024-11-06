using System.ComponentModel;
using System.Linq;
using RoyalArkTest.Interfaces;
using Zenject;

namespace RoyalArkTest
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer diContainer;
        private readonly UIFactoryConfig config;
        
        public UIFactory(DiContainer diContainer, UIFactoryConfig config)
        {
            this.diContainer = diContainer;
            this.config = config;
        }
        
        public void Create()
        {
            CreateCanvas<OverlayCanvas>();
        }

        private void CreateCanvas<T>() where T : Canvas
        {
            Canvas canvasPrefab = config.canvasPrefabs.FirstOrDefault(x => x is T);
            if (canvasPrefab == null) return;
            Canvas canvas = diContainer.InstantiatePrefabForComponent<T>(canvasPrefab);
            canvas.Init();
            diContainer.Bind<IGameScreen>().FromComponentInHierarchy().AsSingle();
        }
    }
}
    