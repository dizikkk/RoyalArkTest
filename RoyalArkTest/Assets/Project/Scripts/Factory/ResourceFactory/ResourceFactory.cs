using System.Collections.Generic;
using RoyalArkTest.Resource;

namespace RoyalArkTest
{
    public class ResourceFactory : IResourceFactory
    {
        private readonly Dictionary<ResourceType, IResource> resources;

        public ResourceFactory()
        {
            resources = new()
            {
                { ResourceType.SmallDiamond, new SmallDiamond() },
                { ResourceType.MediumDiamond, new MediumDiamond() },
                { ResourceType.LargeDiamond, new LargeDiamond() },
                { ResourceType.Brilliant , new Brilliant()},
            };
        }

        public IResource Create(ResourceType resourceType) => resources[resourceType];
    }
}