using UnityEngine;

namespace RoyalArkTest
{
    public abstract class Canvas : MonoBehaviour
    {
        public abstract GameScreen GetGameScreen();
        public abstract void Init();
    }
}