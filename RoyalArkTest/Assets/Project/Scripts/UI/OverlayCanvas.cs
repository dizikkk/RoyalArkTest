using UnityEngine;

namespace RoyalArkTest
{
    public class OverlayCanvas : Canvas
    {
        [SerializeField]
        private GameScreen gameScreen;

        public override GameScreen GetGameScreen() => gameScreen;

        public override void Init()
        {
            ShowScreen();
        }

        private void ShowScreen()
        {
            gameScreen.Init();
        }
    }
}