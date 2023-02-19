using SpiritResources.ResourceModels;
using UnityEngine;

namespace SpiritResources {

    public abstract class ResourceView : MonoBehaviour {

        public abstract void UpdateResourceUI(BaseResource baseResource, int different, int arg3);

        public abstract void InitView(int startNumber);
    }

}