using UnityEngine;

namespace RoyalArkTest
{
    [CreateAssetMenu(fileName = "LevelFactoryConfig", menuName = "Game/Factory/New LevelFactoryConfig", order = 0)]
    public class LevelFactoryConfig : ScriptableObject
    {
        public Level levelPrefab;
    }
}