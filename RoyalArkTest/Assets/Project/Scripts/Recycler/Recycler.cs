using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using RoyalArkTest.Recycle.Configs;
using RoyalArkTest.Resource;
using RoyalArkTest.TimeSkip.Interfaces;
using RoyalArkTest.Utils.ObservableQueue;
using UnityEngine;
using Zenject;

namespace RoyalArkTest.Recycle
{
    public class Recycler : MonoBehaviour, IRecycler, ITimeSkippable
    {
        [SerializeField] 
        private RecyclerConfig config;
        
        public Transform Transform => transform;

        private float skipTime;
        
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
            await WaitRecycleProcess(receipt.recycleDuration);
            IResource newResource = resourceFactory.Create(receipt.outputResourceType);
            recyclableResources.Dequeue();
            process = false;
            playerService.AddResource(newResource, receipt.outputResourceCount);
            Recycle();
        }

        public void AddRecyclableResource(IResource resource) => recyclableResources.Enqueue(resource);

        private ConvertResourcesReceipt GetReceipt(ResourceType inputResourceType) => 
            config.convertResourcesReceipts.FirstOrDefault(x => x.inputResourceType == inputResourceType);
        
        private async UniTask WaitRecycleProcess(float recycleDuration)
        {
            float elapsedTime = 0f;

            while (elapsedTime < recycleDuration - skipTime)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);
                
                elapsedTime += Time.deltaTime;
                Debug.Log($"Прошло времени: {elapsedTime} из {recycleDuration}");
            }
            
            if (skipTime > 0) Math.Min(0f, skipTime -= recycleDuration);
            else ResetSkipTime();
        }

        public void SkipTime(float seconds)
        {
            ResetSkipTime();
            skipTime = seconds;
        }

        private void ResetSkipTime() => skipTime = 0f;
    }
}