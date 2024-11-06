using UnityEngine;

namespace RoyalArkTest.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/Level/New LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        public int shaftCount;
        public Vector3 shaftStartedPosition;
        public Vector3 shaftOffsetToEachOther;
    }
}