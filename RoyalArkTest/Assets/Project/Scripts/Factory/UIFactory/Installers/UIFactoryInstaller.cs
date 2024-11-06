using RoyalArkTest.Interfaces;
using UnityEngine;
using Zenject;

namespace RoyalArkTest.Installers
{
    public class UIFactoryInstaller : MonoInstaller
    {
        [SerializeField]
        private UIFactoryConfig config;
        public override void InstallBindings()
        {
            BindUIFactoryConfig();
            BindUIFactory();
        }

        private void BindUIFactoryConfig() => Container.Bind<UIFactoryConfig>().FromInstance(config).AsSingle();
        private void BindUIFactory()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

        }
    }
}