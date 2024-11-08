namespace RoyalArkTest
{
    public interface ISkipTimeService
    {
        public void GetSkippableItems();
        public void SkipTime(float seconds);
    }
}