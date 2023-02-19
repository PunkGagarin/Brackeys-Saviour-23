using SpiritResources;
using UnityEngine;
using Zenject;

public class ResourceInstaller : MonoInstaller {

    [SerializeField]
    private GameResourceManager _gameResourceManager;

    public override void InstallBindings() {
        Container.Bind<GameResourceManager>()
            .FromInstance(_gameResourceManager)
            .AsSingle();
    }
}