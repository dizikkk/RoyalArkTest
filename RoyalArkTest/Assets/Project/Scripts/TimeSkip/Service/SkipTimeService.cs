using System.Collections.Generic;
using RoyalArkTest.TimeSkip.Interfaces;
using UnityEngine;

namespace RoyalArkTest
{
    public class SkipTimeService : ISkipTimeService
    {
        private List<ITimeSkippable> items = new();

        public void GetSkippableItems()
        {
            MonoBehaviour[] allMonoBehaviours = Object.FindObjectsOfType<MonoBehaviour>();
            
            foreach (var item in allMonoBehaviours)
                if (item is ITimeSkippable myInterface) 
                    items.Add(myInterface);
        }
        
        public void SkipTime(float seconds)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].SkipTime(seconds);
            }
        }
    }
}