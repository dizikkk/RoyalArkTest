using RoyalArkTest.Miners.Interfaces;
using RoyalArkTest.Recycle;
using RoyalArkTest.Shaft.Interfaces;

namespace RoyalArkTest
{
    public interface ILevelFactory
    {
        public void CreateLevel();
        public IRecycler CreateRecycler();
        public IShaft CreateShaft();
        public IMiner CreateMiner();
    }
}