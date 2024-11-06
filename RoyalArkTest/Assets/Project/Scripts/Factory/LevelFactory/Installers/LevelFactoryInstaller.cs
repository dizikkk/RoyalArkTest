using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class LevelFactoryInstaller : MonoInstaller
    {
        [SerializeField]
        private LevelFactoryConfig config;
        
        public override void InstallBindings()
        {
            BindLevelFactoryData();
            BindLevelFactory();
        }

        private void BindLevelFactoryData() => Container.Bind<LevelFactoryConfig>().FromInstance(config).AsSingle();

        
        private void BindLevelFactory() => Container.Bind<ILevelFactory>().To<LevelFactory>().AsSingle();

    }
}