using UnityEngine;

namespace RoyalArkTest
{
    [CreateAssetMenu(fileName = "UIFactoryConfig", menuName = "Game/UI/New UIFactoryConfig", order = 0)]
    public class UIFactoryConfig : ScriptableObject
    {
        public Canvas[] canvasPrefabs;
    }
}