using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour {

    private Button _button;


    // Start is called before the first frame update
    void Start() {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(GoBack);
    }

    // Update is called once per frame
    private void GoBack() {
        SceneManager.LoadScene(0);
    }
}