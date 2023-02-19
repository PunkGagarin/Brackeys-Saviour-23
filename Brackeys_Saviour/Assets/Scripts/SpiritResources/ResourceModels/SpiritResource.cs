using System;
using SpiritResources.ResourceModels;
using UI;
using UnityEngine;

namespace SpiritResources {

    [Serializable]
    public class SpiritResource : BaseResource {

        public SpiritResource(int startValue, int maxValue, int minValue, SpiritResourceType type) {
            base.type = type;
            _resourceCount = startValue;
            _initCount = startValue;
            maxRes = maxValue;
            this.minValue = minValue;
        }
    }

}