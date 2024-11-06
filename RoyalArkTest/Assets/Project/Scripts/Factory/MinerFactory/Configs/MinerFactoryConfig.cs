using RoyalArkTest.Miners;
using UnityEngine;

namespace RoyalArkTest
{
    [CreateAssetMenu(fileName = "MinerFactoryConfig", menuName = "Game/Factory/New MinerFactoryConfig", order = 0)]
    public class MinerFactoryConfig : ScriptableObject
    {
        public Miner minerPrefab;
    }
}