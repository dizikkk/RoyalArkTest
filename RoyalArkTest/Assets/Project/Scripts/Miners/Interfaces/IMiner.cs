using RoyalArkTest.Recycle;
using RoyalArkTest.Shaft.Interfaces;

namespace RoyalArkTest.Miners.Interfaces
{
    public interface IMiner
    {
        public void Init();
        public void Mine(float duration);
        public void SetShaft(IShaft shaft);
        public void SetRecycler(IRecycler recycler);
    }
}