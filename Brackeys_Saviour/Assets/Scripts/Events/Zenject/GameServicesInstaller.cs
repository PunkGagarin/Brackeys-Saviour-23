using Zenject;

namespace Events.Zenject {
    public class GameServicesInstaller : MonoInstaller {
        public override void InstallBindings() {
            
            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}