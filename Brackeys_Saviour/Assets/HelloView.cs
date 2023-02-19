using UI;
using UnityEngine;
using UnityEngine.UI;

public class HelloView : ContentUI {

    [SerializeField]
    private Button _button;

    protected override void Awake() {
        base.Awake();
        _button = GetComponentInChildren<Button>(true);
        _button.onClick.AddListener(HideContent);
    }
}