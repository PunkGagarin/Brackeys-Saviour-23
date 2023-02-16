using UnityEngine;
using UnityEngine.UI;

namespace SpiritResources {

    public class HappinessView : MonoBehaviour {

        [SerializeField]
        private Slider _slider;

        public void UpdateHappiness(int newNumber) {
            _slider.value = newNumber;
        }
    }

}