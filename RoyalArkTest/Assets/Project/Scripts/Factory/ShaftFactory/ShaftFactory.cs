using RoyalArkTest.Shaft.Interfaces;
using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class ShaftFactory : IShaftFactory
    {
        private readonly DiContainer diContainer;
        private readonly ShaftFactoryConfig config;
        
        public ShaftFactory(DiContainer diContainer, ShaftFactoryConfig config)
        {
            this.diContainer = diContainer;
            this.config = config;
        }
        
        public IShaft Create()
        {
            Shaft.Shaft shaft = diContainer.InstantiatePrefabForComponent<Shaft.Shaft>(
                config.shaftPrefab,
                Vector3.zero, 
                Quaternion.identity,
                null);
            return shaft;
        }
    }
}