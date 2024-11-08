using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private float timeToSkip;
        
        private IGameFactory gameFactory;
        private ISkipTimeService skipTimeService;
        
        [Inject]
        public void Construct(IGameFactory gameFactory) => this.gameFactory = gameFactory;

        private void Start()
        {
            gameFactory.CreateGameplayEntities();
            gameFactory.CreateUI();

            skipTimeService = new SkipTimeService();
            skipTimeService.GetSkippableItems();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) skipTimeService.SkipTime(timeToSkip);
        }
    }
}