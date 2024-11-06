using System.Collections.Generic;
using RoyalArkTest.Rewind.Interfaces;
using UnityEngine;

namespace RoyalArkTest
{
    public class RewindService : IRewindService
    {
        private List<IDurationChangeable> items = new();

        private float multiplier;
        private bool isRewind;
        
        public RewindService(float multiplier) => this.multiplier = multiplier;

        public void GetChangeableItems()
        {
            MonoBehaviour[] allMonoBehaviours = Object.FindObjectsOfType<MonoBehaviour>();
            
            foreach (var item in allMonoBehaviours)
                if (item is IDurationChangeable myInterface) 
                    items.Add(myInterface);
        }

        public void StartRewind()
        {
            if (isRewind) return;
            isRewind = true;
            for (int i = 0; i < items.Count; i++) items[i].ChangeDuration(multiplier);
        }

        public void StopRewind()
        {
            if (!isRewind) return;
            isRewind = false;
            for (int i = 0; i < items.Count; i++) items[i].ResetDuration();
        }
    }
}