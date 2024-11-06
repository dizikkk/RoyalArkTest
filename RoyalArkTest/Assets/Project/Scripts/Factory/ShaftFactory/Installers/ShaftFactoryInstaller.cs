using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class ShaftFactoryInstaller : MonoInstaller
    {
        [SerializeField]
        private ShaftFactoryConfig config;
        
        public override void InstallBindings()
        {
            BindShaftFactoryData();
            BindShaftFactory();
        }

        private void BindShaftFactoryData() => Container.Bind<ShaftFactoryConfig>().FromInstance(config).AsSingle();
        
        private void BindShaftFactory() => Container.Bind<IShaftFactory>().To<ShaftFactory>().AsSingle();
    }
}