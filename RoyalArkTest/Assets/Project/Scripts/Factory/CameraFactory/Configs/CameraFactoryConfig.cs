using UnityEngine;

namespace RoyalArkTest
{
    [CreateAssetMenu(fileName = "CameraFactoryConfig", menuName = "Game/Factory/New CameraFactoryConfig", order = 0)]
    public class CameraFactoryConfig : ScriptableObject
    {
        public Camera cameraPrefab;
        public Vector3 position;
        public Vector3 rotation;
    }
}