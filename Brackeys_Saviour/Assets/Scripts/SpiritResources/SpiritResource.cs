using System;
using UI;
using UnityEngine;

namespace SpiritResources {

    [Serializable]
    public class SpiritResource : BaseResource {

        private ResourcePanelUI _resourcePanelUI;
    
        public SpiritResource(ResourcePanelUI resourcePanelUI, SpiritResourceType type) {
            _resourcePanelUI = resourcePanelUI;
            _type = type;
        }

        protected override void UpdateUI() {
            _resourcePanelUI.UpdateResource(_type, _resourceCount);
        }
    }

}