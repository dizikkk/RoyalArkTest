using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class MinerFactoryInstaller : MonoInstaller
    {
        [SerializeField]
        private MinerFactoryConfig config;
        
        public override void InstallBindings()
        {
            BindRecyclerFactoryData();
            BindRecyclerFactory();
        }

        private void BindRecyclerFactoryData() => Container.Bind<MinerFactoryConfig>().FromInstance(config).AsSingle();
        
        private void BindRecyclerFactory() => Container.Bind<IMinerFactory>().To<MinerFactory>().AsSingle();
    }
}