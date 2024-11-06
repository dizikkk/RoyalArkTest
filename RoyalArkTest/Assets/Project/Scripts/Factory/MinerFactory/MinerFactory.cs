using RoyalArkTest.Miners;
using RoyalArkTest.Miners.Interfaces;
using RoyalArkTest.Recycle;
using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class MinerFactory : IMinerFactory
    {
        private readonly DiContainer diContainer;
        private readonly MinerFactoryConfig config;
        
        public MinerFactory(DiContainer diContainer, MinerFactoryConfig config)
        {
            this.diContainer = diContainer;
            this.config = config;
        }
        
        public IMiner Create()
        {
            Miner miner = diContainer.InstantiatePrefabForComponent<Miner>(
                config.minerPrefab,
                Vector3.zero, 
                Quaternion.identity,
                null);

            return miner;
        }
    }
}