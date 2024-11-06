namespace RoyalArkTest.Resource
{
    public class LargeDiamond : IResource
    {
        private readonly ResourceType resourceType;
        
        public LargeDiamond() => resourceType = ResourceType.LargeDiamond;

        public ResourceType GetResourceType() => resourceType;
    }
}