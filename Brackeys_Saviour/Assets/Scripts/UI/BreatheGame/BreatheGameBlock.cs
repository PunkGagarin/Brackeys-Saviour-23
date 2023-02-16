using UnityEngine;
using Zenject.Asteroids;

namespace UI.BreatheGame {

    public class BreatheGameBlock : MonoBehaviour {

        private RectTransform _rectTransform;
    
        public float startVal { get; private set; }
        public float endVal { get; private set; }
        public float width { get; private set; }
        

        public bool IsInBlock(float val) {
            // val += _rectTransform.sizeDelta.x / 2;
            return val <= endVal && val >= startVal;
        }

        public void SaveValues(float width) {
            _rectTransform = GetComponent<RectTransform>();
            this.width = width;
            startVal = _rectTransform.anchoredPosition.x;
            endVal = startVal + width;
            Debug.Log($"new block values start: {startVal}, end: {endVal}, width: {width}");
        }
    }

}