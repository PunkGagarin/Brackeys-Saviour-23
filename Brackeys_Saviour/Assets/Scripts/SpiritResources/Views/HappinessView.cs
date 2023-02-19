using SpiritResources.ResourceModels;
using UnityEngine;
using UnityEngine.UI;

namespace SpiritResources {

    public class HappinessView : ResourceView {

        private float _maxHappiness;

        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private Image _happinessImage;

        public override void UpdateResourceUI(BaseResource resource, int newNumber, int diffNumber) {
            _slider.value = newNumber;
        }

        public override void InitView(int startNumber) {
            _slider.value = startNumber;
        }
    }

}