using TMPro;
using UnityEngine;

namespace SpiritResources {

    public class MoneyView : ResourceView {
        
        [SerializeField]
        private TextMeshProUGUI _text;
        
        public override void UpdateResourceUI(int newNumber, int different) {
            _text.text = newNumber.ToString();
        }

        public override void InitView(int startNumber) {
            _text.text = startNumber.ToString();
        }
    }

}