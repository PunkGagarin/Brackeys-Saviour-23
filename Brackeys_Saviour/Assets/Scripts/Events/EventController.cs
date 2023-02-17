using Events.GameEvents;
using Events.Pools;
using Events.UI;
using UnityEngine;
using Zenject;

namespace Events {

    public class EventController : MonoBehaviour {

        [Inject]
        private BasePoolImpl _gameEventPool;

        [Inject]
        private EventView _eventView;

        private void Awake() {
            _gameEventPool.InitPool();
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