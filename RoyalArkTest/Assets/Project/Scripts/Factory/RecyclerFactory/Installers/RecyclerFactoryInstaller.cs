using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class RecyclerFactoryInstaller : MonoInstaller
    {
        [SerializeField]
        private RecyclerFactoryConfig config;
        
        public override void InstallBindings()
        {
            BindRecyclerFactoryData();
            BindRecyclerFactory();
        }

        private void BindRecyclerFactoryData() => Container.Bind<RecyclerFactoryConfig>().FromInstance(config).AsSingle();
        
        private void BindRecyclerFactory() => Container.Bind<IRecyclerFactory>().To<RecyclerFactory>().AsSingle();
    }
}