using System.Linq;
using Cysharp.Threading.Tasks;
using RoyalArkTest.Recycle.Configs;
using RoyalArkTest.Resource;
using RoyalArkTest.Rewind.Interfaces;
using RoyalArkTest.Utils.ObservableQueue;
using UnityEngine;
using Zenject;

namespace RoyalArkTest.Recycle
{
    public class Recycler : MonoBehaviour, IRecycler, IDurationChangeable
    {
        [SerializeField] 
        private RecyclerConfig config;
        
        public Transform Transform => transform;

        private float recycleDuration;
        private ObservableQueue<IResource> recyclableResources;
        private IResourceFactory resourceFactory;
        private IPlayerService playerService;
        private bool process;

        [Inject]
        private void Construct(IResourceFactory resourceFactory, IPlayerService playerService)
        {
            this.resourceFactory = resourceFactory;
            this.playerService = playerService;
        }

        public void Init()
        {
            recyclableResources = new ObservableQueue<IResource>();
            recyclableResources.ItemWasAdded += Recycle;
        }

        public async void Recycle()
        {
            if (process) return;
            if (recyclableResources.Count <= 0) return;
            
            process = true;
            ConvertResourcesReceipt receipt = GetReceipt(recyclableResources.Peek().GetResourceType());
            recycleDuration = receipt.recycleDuration;
            await WaitRecycleProcess();
            IResource newResource = resourceFactory.Create(receipt.outputResourceType);
            recyclableResources.Dequeue();
            process = false;
            playerService.AddResource(newResource, receipt.outputResourceCount);
            Recycle();
        }

        public void AddRecyclableResource(IResource resource) => recyclableResources.Enqueue(resource);

        private ConvertResourcesReceipt GetReceipt(ResourceType inputResourceType) => 
            config.convertResourcesReceipts.FirstOrDefault(x => x.inputResourceType == inputResourceType);

        public void ChangeDuration(float multiplier) => recycleDuration /= multiplier;

        public void ResetDuration()
        {
            if (recyclableResources.Count <= 0) return;
            ConvertResourcesReceipt receipt = GetReceipt(recyclableResources.Peek().GetResourceType());
            recycleDuration = receipt.recycleDuration;
        }
        
        private async UniTask WaitRecycleProcess()
        {
            float elapsedTime = 0f;

            while (elapsedTime < recycleDuration)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);
                elapsedTime += Time.deltaTime;
                Debug.Log($"Прошло времени: {elapsedTime} из {recycleDuration}");
            }
        }
    }
}