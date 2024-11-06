using RoyalArkTest.Configs;
using RoyalArkTest.Miners.Interfaces;
using RoyalArkTest.Recycle;
using RoyalArkTest.Shaft.Interfaces;
using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig config;

        private IRecycler recycler;
        private ILevelFactory levelFactory;
        
        [Inject]
        private void Construct(ILevelFactory levelFactory)
        {
            this.levelFactory = levelFactory;
        }

        public void Init()
        {
            CreateRecycler();
            CreateShafts();
        }

        private void CreateRecycler()
        {
            recycler = levelFactory.CreateRecycler();
            recycler.Init();
        }

        private void CreateShafts()
        {
            Vector3 spawnPosition = config.shaftStartedPosition;
            for (int i = 0; i < config.shaftCount; i++)
            {
                IShaft shaft = levelFactory.CreateShaft();
                shaft.Init();
                shaft.Transform.position = spawnPosition;
                CreateMiner(shaft, recycler);
                spawnPosition += config.shaftOffsetToEachOther;
            }
        }

        private void CreateMiner(IShaft shaft, IRecycler recycler)
        {
            IMiner miner = levelFactory.CreateMiner();
            miner.SetRecycler(recycler);
            miner.SetShaft(shaft);
            miner.Init();
        }
    }
}
