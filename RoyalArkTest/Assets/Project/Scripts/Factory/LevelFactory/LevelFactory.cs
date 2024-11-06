using RoyalArkTest.Miners.Interfaces;
using RoyalArkTest.Recycle;
using RoyalArkTest.Shaft.Interfaces;
using UnityEditorInternal;
using Zenject;

namespace RoyalArkTest
{
    public class LevelFactory : ILevelFactory
    {
        private readonly DiContainer diContainer;
        private LevelFactoryConfig config;
        private Level level;
        
        public LevelFactory(DiContainer diContainer, LevelFactoryConfig config)
        {
            this.diContainer = diContainer;
            this.config = config;
        }

        public void CreateLevel()
        {
            level = diContainer.InstantiatePrefabForComponent<Level>(config.levelPrefab);
            level.Init();
        }

        public IRecycler CreateRecycler()
        {
            IRecyclerFactory recyclerFactory = diContainer.Resolve<IRecyclerFactory>();
            return recyclerFactory.Create();
        }

        public IShaft CreateShaft()
        {
            IShaftFactory shaftFactory = diContainer.Resolve<IShaftFactory>();
            return shaftFactory.Create();
        }

        public IMiner CreateMiner()
        {
            IMinerFactory minerFactory = diContainer.Resolve<IMinerFactory>();
            return minerFactory.Create();
        }

        private void CreateLevelEntities()
        {
            
        }
    }
}