using UnityEngine;
using Zenject;

namespace RoyalArkTest
{
    public class Game : MonoBehaviour
    {
        private IGameFactory gameFactory;
        private IRewindService rewindService;
        
        [Inject]
        public void Construct(IGameFactory gameFactory) => this.gameFactory = gameFactory;

        private async void Start()
        {
            gameFactory.CreateGameplayEntities();
            gameFactory.CreateUI();

            rewindService = new RewindService(2);
            rewindService.GetChangeableItems();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
                rewindService.StartRewind();
            
            if (Input.GetKey(KeyCode.D))
                rewindService.StopRewind();
        }
    }
}