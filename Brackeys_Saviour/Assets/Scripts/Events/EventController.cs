using Events.GameEvents;
using Events.Pools;
using Events.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Events {

    public class EventController : MonoBehaviour {

        [Inject]
        private BasePoolImpl _gameEventPool;

        [Inject]
        private GameEventUI _eventView;

        [SerializeField]
        private Button _testButton;

        [SerializeField]
        private TextAsset _storyTest;

        private void Awake() {
            _gameEventPool.InitPool();
            _testButton.onClick.AddListener(TestStory);
        }

        private void TestStory() {
            _eventView.TryFirstStory(_storyTest);
        }

        public void EventHandle(BaseGameEvent gameEvent) {
            UpdateUI(gameEvent);
        }

        private void UpdateUI(BaseGameEvent baseGameEvent) {
            _eventView.UpdateUiForEvent(baseGameEvent);
        }

        public BaseGameEvent GetRandomEvent() {
            return _gameEventPool.GetRandomPoolEvent();
        }
    }

}