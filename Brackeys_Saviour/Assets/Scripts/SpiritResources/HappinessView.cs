using UnityEngine;
using UnityEngine.UI;

namespace SpiritResources {

    public class HappinessView : MonoBehaviour {

        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private Image _happinessImage;

        public void UpdateHappiness(int newNumber) {
            _slider.value = newNumber;
        }
        
    }

}