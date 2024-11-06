using RoyalArkTest.Resource;

namespace RoyalArkTest
{
    public interface IResourceFactory
    {
        public IResource Create(ResourceType resourceType);
    }
}