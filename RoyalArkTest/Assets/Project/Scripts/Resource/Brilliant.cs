namespace RoyalArkTest.Resource
{
    public class Brilliant : IResource
    {
        private readonly ResourceType resourceType;
        
        public Brilliant() => resourceType = ResourceType.Brilliant;

        public ResourceType GetResourceType() => resourceType;
    }
}