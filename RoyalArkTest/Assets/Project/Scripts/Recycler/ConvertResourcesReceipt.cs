using System;
using RoyalArkTest.Resource;

namespace RoyalArkTest.Recycle
{
    [Serializable]
    public class ConvertResourcesReceipt
    {
        public ResourceType inputResourceType;
        public ResourceType outputResourceType;
        public int outputResourceCount;
        public float recycleDuration;
    }
}