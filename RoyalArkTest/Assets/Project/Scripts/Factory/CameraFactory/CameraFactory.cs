using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class CameraFactory : ICameraFactory
    {
        private readonly DiContainer diContainer;
        private readonly CameraFactoryConfig config;
        
        public CameraFactory(DiContainer diContainer, CameraFactoryConfig config)
        {
            this.diContainer = diContainer;
            this.config = config;
        }
        
        public void Create() => CreateFollowCamera();

        private void CreateFollowCamera()
        {
            Camera camera = diContainer.InstantiatePrefabForComponent<Camera>(
                config.cameraPrefab,
                config.position, 
                Quaternion.Euler(config.rotation),
                null);
        }
    }
}