using RoyalArkTest.Recycle;
using UnityEngine;

namespace RoyalArkTest
{
    [CreateAssetMenu(fileName = "RecyclerFactoryConfig", menuName = "Game/Factory/New RecyclerFactoryConfig", order = 0)]
    public class RecyclerFactoryConfig : ScriptableObject
    {
        public Recycler recyclerPrefab;
    }
}