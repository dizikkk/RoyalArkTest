using Cysharp.Threading.Tasks;
using DG.Tweening;
using RoyalArkTest.Miners.Configs;
using RoyalArkTest.Miners.Interfaces;
using RoyalArkTest.Recycle;
using RoyalArkTest.Resource;
using RoyalArkTest.Rewind.Interfaces;
using RoyalArkTest.Shaft.Interfaces;
using UnityEngine;

namespace RoyalArkTest.Miners
{
    public class Miner : MonoBehaviour, IMiner, IDurationChangeable
    {
        [SerializeField] 
        private MinerConfig config;

        private float speed;
        private float distance;
        
        private Tweener tween;
        private Transform movePoint;
        
        private IShaft shaft;
        private IRecycler recycler;
        private IResource minedResource;
        
        public void Init()
        {
            speed = config.speed;
            StartWorkCycle();
        }

        public async void Mine(float duration)
        {
            await UniTask.WaitForSeconds(duration);
            minedResource = shaft.GiveResource();
            MoveTo(recycler.Transform).OnComplete(() =>
            {
                GiveMinedResource(minedResource);
                StartWorkCycle();
            });
        }

        private void StartWorkCycle()
        {
            MoveTo(shaft.Transform).OnComplete(() =>
            {
                Mine(config.mineDuration);
            });
        }
        
        public void SetShaft(IShaft shaft) => this.shaft = shaft;

        public void SetRecycler(IRecycler recycler) => this.recycler = recycler;

        private void GiveMinedResource(IResource minedResource) => recycler.AddRecyclableResource(minedResource);

        private Tween MoveTo(Transform transform)
        {
            movePoint = transform;
            distance = Vector3.Distance(this.transform.position, movePoint.position);
            tween = gameObject.transform.DOMove(movePoint.position, distance / speed).SetEase(Ease.Linear);
            return tween;
        }

        public void ChangeDuration(float multiplier)
        {
            speed *= multiplier;
            ChangeEndValueTweener(multiplier);
        }

        public void ResetDuration()
        {
            speed = config.speed;
            ChangeEndValueTweener(1f);
        }

        private void ChangeEndValueTweener(float multiplier) => tween.timeScale = multiplier;
    }
}