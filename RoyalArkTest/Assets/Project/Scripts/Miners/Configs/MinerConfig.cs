using UnityEngine;

namespace RoyalArkTest.Miners.Configs
{
    [CreateAssetMenu(fileName = "MinerConfig", menuName = "Game/Miner/New MinerConfig", order = 0)]
    public class MinerConfig : ScriptableObject
    {
        public float speed;
        public float mineDuration;
    }
}