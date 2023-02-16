using System;
using DG.Tweening;
using UnityEngine;

namespace UI {

    public class ResourcePanelContentUI : MonoBehaviour {

        private RectTransform _rectTransform;

        private void Awake() {
            _rectTransform = GetComponent<RectTransform>();
        }
        //
        // private void OnEnable() {
        //     _rectTransform.DOAnchorPosY(0, 1f);
        // }
        //
        // private void OnDisable() {
        //     _rectTransform.DOAnchorPosY(-300, 1f);
        // }
    }

}