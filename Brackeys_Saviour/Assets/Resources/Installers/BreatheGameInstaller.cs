using UI.BreatheGame;
using UnityEngine;
using Zenject;

namespace Resources.Installers {

    public class BreatheGameInstaller : MonoInstaller {

        [SerializeField]
        private MiniGameUI _miniGameUI;
    
        public override void InstallBindings() {
            Container.Bind<MiniGameUI>().FromInstance(_miniGameUI).AsSingle();
        }
    }

}