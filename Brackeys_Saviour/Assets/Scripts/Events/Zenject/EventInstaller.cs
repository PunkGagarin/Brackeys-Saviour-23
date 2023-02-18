using Events.Pools;
using Events.UI;
using UnityEngine;
using Zenject;

namespace Events.Zenject {

    public class EventInstaller : MonoInstaller {


        [SerializeField]
        private EventController _eventController;

        [SerializeField]
        private GameEventUI _eventView;

        public override void InstallBindings() {
            Container.Bind<BasePoolImpl>()
                .FromNew()
                .AsSingle();

            Container.Bind<GameEventUI>()
                .FromInstance(_eventView)
                .AsSingle();

            Container.Bind<EventController>()
                .FromInstance(_eventController)
                .AsSingle();
        }
    }

}