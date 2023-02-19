using Events;
using ModestTree;
using SpiritResources;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour {


    public bool isPlaying { get; private set; }

    [Inject]
    private GameResourceManager _gameResourceManager;

    [Inject]
    private EventController _eventController;

    [SerializeField]
    private EndGameView _endGameView;


    [SerializeField]
    private Button _testButton;

    private void Start() {
        _testButton.onClick.AddListener(TestEnding);
    }

    private void TestEnding() {
        CheckGoodEndGame(SpiritResourceType.Happiness);
    }

    private void Awake() {
        Assert.IsNotNull(_endGameView);
        _gameResourceManager.OnMinValueReach += CheckForBadEndGame;
        _gameResourceManager.OnMaxValueReach += CheckGoodEndGame;
        _eventController.OnMaxValueReach += CheckForEnding;
    }

    private void CheckForBadEndGame(SpiritResourceType type) {
        if (type == SpiritResourceType.Volunteers) return;

        isPlaying = false;
        _eventController.StopTimer();
        Debug.Log("You cant continue");
        _endGameView.ShowBadEnding(type);
    }

    private void CheckGoodEndGame(SpiritResourceType type) {
        if (type != SpiritResourceType.Happiness) return;

        isPlaying = false;
        _eventController.StopTimer();
        Debug.Log("You cant continue");
        _endGameView.ShowGoodEnding();
    }

    private void CheckForEnding() {
        var happyCount = _gameResourceManager.GetCurrentResource(SpiritResourceType.Happiness);
        var initHappiness = _gameResourceManager.GetInitResource(SpiritResourceType.Happiness);
        var volunteersCount = _gameResourceManager.GetCurrentResource(SpiritResourceType.Volunteers);

        isPlaying = false;
        _eventController.StopTimer();
        _endGameView.ShowEventEnding(happyCount, volunteersCount, initHappiness);
    }


}