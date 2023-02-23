using Audio;
using UnityEngine;
using Zenject;

namespace Events.Zenject {
    public class GameServicesInstaller : MonoInstaller {
        [SerializeField] private AudioManager _audioManager;
        public override void InstallBindings() {

            Container.Bind<AudioManager>().FromInstance(_audioManager).AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}