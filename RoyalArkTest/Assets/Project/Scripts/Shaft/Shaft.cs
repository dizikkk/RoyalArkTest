using RoyalArkTest.Resource;
using RoyalArkTest.Shaft.Interfaces;
using UnityEngine;
using Zenject;

namespace RoyalArkTest.Shaft
{
    public class Shaft : MonoBehaviour, IShaft
    {
        [SerializeField]
        private ShaftConfig config;

        private IResourceFactory resourceFactory;
        
        public Transform Transform => transform;
        
        [Inject]
        private void Construct(IResourceFactory resourceFactory) => this.resourceFactory = resourceFactory;

        public void Init()
        {

        }

        private ResourceType GetRandomResourceType()
        {
            int randomValue = Random.Range(0, config.possibleResources.Length);
            return config.possibleResources[randomValue];
        }
        
        public int GetMinerCount() => config.minersCount;
        
        public IResource GiveResource() => resourceFactory.Create(GetRandomResourceType());
    }
}