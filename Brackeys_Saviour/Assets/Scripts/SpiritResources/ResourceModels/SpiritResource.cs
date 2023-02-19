using System;
using UI;
using UnityEngine;

namespace SpiritResources {

    [Serializable]
    public class SpiritResource : BaseResource {

        public SpiritResource(int startValue, int maxValue, SpiritResourceType type) {
            _type = type;
            _resourceCount = startValue;
            _maxRes = maxValue;
        }
    }

}