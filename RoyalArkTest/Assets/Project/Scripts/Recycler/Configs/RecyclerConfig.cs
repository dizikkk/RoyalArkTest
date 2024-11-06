using UnityEngine;

namespace RoyalArkTest.Recycle.Configs
{
    [CreateAssetMenu(fileName = "RecyclerConfig", menuName = "Game/Recycler/New RecyclerConfig", order = 0)]
    public class RecyclerConfig : ScriptableObject
    {
        public ConvertResourcesReceipt[] convertResourcesReceipts;
    }
}