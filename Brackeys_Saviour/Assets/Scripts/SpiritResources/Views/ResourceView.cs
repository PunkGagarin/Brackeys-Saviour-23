using UnityEngine;

namespace SpiritResources {

    public abstract class ResourceView : MonoBehaviour {

        public abstract void UpdateResourceUI(int newNumber, int different);

        public abstract void InitView(int startNumber);
    }

}