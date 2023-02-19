using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI {
   public class MenuManager : MonoBehaviour {
      
      [Inject] 
      private SceneLoader _sceneLoader;

      [SerializeField]
      private Button _startGameButton;

      private void Start() {
         _startGameButton.onClick.AddListener(() => _sceneLoader.Load(1));
      }
   }
}
