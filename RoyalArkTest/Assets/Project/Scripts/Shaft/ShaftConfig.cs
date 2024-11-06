using RoyalArkTest.Resource;
using UnityEngine;

namespace RoyalArkTest.Shaft
{
    [CreateAssetMenu(fileName = "ShaftConfig", menuName = "Game/Shaft/New ShaftConfig", order = 0)]
    public class ShaftConfig : ScriptableObject
    {
        public int minersCount;
        public ResourceType[] possibleResources;
    }
}