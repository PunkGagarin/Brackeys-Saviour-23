using System;
using UnityEngine;

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
            
            var collider = gameObject.GetComponent<BoxCollider>();
            var rectTransform = gameObject.GetComponent<RectTransform>();
            collider.size = new Vector3(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y, 0);
            collider.center = new Vector3(rectTransform.sizeDelta.x / 2, 0, 0);
        }
    }
}