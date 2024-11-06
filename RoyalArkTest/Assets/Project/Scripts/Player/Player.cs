using System.Collections.Generic;
using RoyalArkTest.Interfaces;
using RoyalArkTest.Resource;

namespace RoyalArkTest
{
    public class Player : IPlayer
    {
        private Dictionary<ResourceType, List<IResource>> resources;

        private IUIService uiService;
        
        public Player(IUIService uiService)
        {
            this.uiService = uiService;
            resources = new Dictionary<ResourceType, List<IResource>>();
        }

        public void AddResource(IResource resource, int count)
        {
            if (!resources.ContainsKey(resource.GetResourceType()))
                resources.Add(resource.GetResourceType(), new List<IResource>());
            
            for (int i = 0; i < count; i++) resources[resource.GetResourceType()].Add(resource);
            
            uiService.RefreshPlayerResources(resources);
        }
    }
}