using RoyalArkTest.Recycle;
using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class RecyclerFactory : IRecyclerFactory
    {
        private readonly DiContainer diContainer;
        private readonly RecyclerFactoryConfig config;
        
        public RecyclerFactory(DiContainer diContainer, RecyclerFactoryConfig config)
        {
            this.diContainer = diContainer;
            this.config = config;
        }
        
        public IRecycler Create()
        {
            Recycler recycler = diContainer.InstantiatePrefabForComponent<Recycler>(
                config.recyclerPrefab,
                Vector3.zero, 
                Quaternion.identity,
                null);
            return recycler;
        }
    }
}