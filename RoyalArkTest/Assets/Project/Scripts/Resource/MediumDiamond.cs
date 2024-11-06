namespace RoyalArkTest.Resource
{
    public class MediumDiamond : IResource
    {
        private readonly ResourceType resourceType;
        
        public MediumDiamond() => resourceType = ResourceType.MediumDiamond;

        public ResourceType GetResourceType() => resourceType;
    }
}