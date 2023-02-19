using SpiritResources.ResourceModels;
using TMPro;
using UnityEngine;

namespace SpiritResources {

    public class VolunteersView : ResourceView {

        [SerializeField]
        private TextMeshProUGUI _text;
        
        public override void UpdateResourceUI(BaseResource resource, int newNumber, int diffNUmber) {
            _text.text = newNumber.ToString();
        }

        public override void InitView(int startNumber) {
            _text.text = startNumber.ToString();
        }
    }

}