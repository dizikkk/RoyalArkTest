using UnityEngine;

namespace RoyalArkTest
{
    [CreateAssetMenu(fileName = "ShaftFactoryConfig", menuName = "Game/Factory/New ShaftFactoryConfig", order = 0)]
    public class ShaftFactoryConfig : ScriptableObject
    {
        public Shaft.Shaft shaftPrefab;
    }
}