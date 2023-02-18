using UnityEngine;

namespace UI.BreatheGame {
    public class SliderArrow : MonoBehaviour {

        public bool EntersBlockPosition { get; private set; }

        public BreatheGameBlock BreatheGameBlock { get; set; } 

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("BreathCatchBlock")) {
                EntersBlockPosition = true;
                BreatheGameBlock = other.GetComponent<BreatheGameBlock>();
            }
        }
        
        private void OnTriggerExit(Collider other) {
            if (other.gameObject.CompareTag("BreathCatchBlock")) {
                EntersBlockPosition = false;
                BreatheGameBlock = null;
            }
        }
    }
}