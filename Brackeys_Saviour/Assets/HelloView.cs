using UI;
using UnityEngine;
using UnityEngine.UI;

public class HelloView : ContentUI {

    private Button _button;

    protected override void Awake() {
        base.Awake();
        ShowContent();
        _button = GetComponentInChildren<Button>(true);
        _button.onClick.AddListener(HideContent);
    }
}