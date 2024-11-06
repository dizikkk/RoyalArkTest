namespace RoyalArkTest.Resource
{
    public class SmallDiamond : IResource
    {
        private readonly ResourceType resourceType;
        
        public SmallDiamond() => resourceType = ResourceType.SmallDiamond;

        public ResourceType GetResourceType() => resourceType;
    }
}