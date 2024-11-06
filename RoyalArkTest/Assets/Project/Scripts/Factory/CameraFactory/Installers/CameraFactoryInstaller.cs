using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class CameraFactoryInstaller : MonoInstaller
    {
        [SerializeField]
        private CameraFactoryConfig config;
        
        public override void InstallBindings()
        {
            BindCameraFactoryData();
            BindCameraFactory();
        }

        private void BindCameraFactoryData() => Container.Bind<CameraFactoryConfig>().FromInstance(config).AsSingle();
        
        private void BindCameraFactory() => Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
    }
}