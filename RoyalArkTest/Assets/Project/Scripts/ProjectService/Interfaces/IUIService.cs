using System;
using System.Collections.Generic;
using RoyalArkTest.Resource;

namespace RoyalArkTest
{
    public interface IUIService
    {
        public Action<int> PlayerResourcesChanged { get; set; }
        public void RefreshPlayerResources(Dictionary<ResourceType, List<IResource>> resources);
    }
}