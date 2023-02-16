using System;
using DG.Tweening;
using SpiritResources;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace UI {

    public class ResourcePanelUI : ContentUI {

        [SerializeField]
        private Button _hideButton;

        [SerializeField]
        private Button _showButton;


        private void Start() {
            _hideButton.onClick.AddListener(HideContent);
            _showButton.onClick.AddListener(ShowContent);
        }

        public override void ShowContent() {
            _content.gameObject.SetActive(true);
            _content.GetComponent<RectTransform>().DOAnchorPosY(0f, 1f);
        }

        public override void HideContent() {
            var rectTransform = _content.GetComponent<RectTransform>();
            var doAnchorPosY = rectTransform.DOAnchorPosY(-rectTransform.rect.height, 1f);
            doAnchorPosY.OnComplete(() => { _content.gameObject.SetActive(false); });
        }

        public void UpdateResource(SpiritResourceType type, int newNumber) {
            
        }
    }

}