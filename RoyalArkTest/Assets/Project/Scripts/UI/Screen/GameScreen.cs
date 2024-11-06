using RoyalArkTest.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class GameScreen : Screen, IGameScreen
    {
        [SerializeField]
        private TextMeshProUGUI playerResourcesText;

        private IUIService uiService;

        [Inject]
        private void Construct(IUIService uiService) => this.uiService = uiService;

        public override void Init() => uiService.PlayerResourcesChanged += UpdateScreen;

        public override void Hide() => gameObject.SetActive(false);
        
        public void UpdateScreen(int resourcesCount) => playerResourcesText.text = $"Brilliants : {resourcesCount}";

        private void OnDestroy()
        {
            uiService.PlayerResourcesChanged -= UpdateScreen;
        }
    }
}