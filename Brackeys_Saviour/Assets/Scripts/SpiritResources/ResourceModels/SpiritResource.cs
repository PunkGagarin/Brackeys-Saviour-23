using System;
using UI;
using UnityEngine;

namespace SpiritResources {

    [Serializable]
    public class SpiritResource : BaseResource {

        // private ResourcePanelUI _resourcePanelUI;
    
        public SpiritResource(int startValue, int MaxValue, SpiritResourceType type) {
            _type = type;
        }
    }

}