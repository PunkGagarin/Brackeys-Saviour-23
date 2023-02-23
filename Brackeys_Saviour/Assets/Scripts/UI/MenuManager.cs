using Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI {
   public class MenuManager : MonoBehaviour {
      
      [Inject] 
      private SceneLoader _sceneLoader;

      [Inject] 
      private AudioManager _audioManager;

      [SerializeField]
      private Button _startGameButton;

      private void Start() {
         _startGameButton.onClick.AddListener(() => {
            _audioManager.PlayEffectSound("snd_ui_click");
            _sceneLoader.Load(1);
         });
      }
   }
}
