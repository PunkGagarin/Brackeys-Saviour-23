using System;
using UnityEngine;

namespace SpiritResources.ResourceModels {

    [Serializable]
    public abstract class BaseResource {

        public Action<BaseResource, int, int> OnValueChange = delegate { };
        
        [SerializeField]
        protected int _initCount;
        
        [SerializeField]
        protected int _resourceCount;

        [field: SerializeField]
        public int maxRes { get; set; }

        [field: SerializeField]
        public SpiritResourceType type { get; protected set; }

        public int minValue { get; set; }

        public bool IsEnough(int number) {
            return _resourceCount >= number;
        }

        public void AddResource(int number) {
            _resourceCount += number;
            OnValueChange.Invoke(this, _resourceCount, number);
        }

        public int GetCurrentResource() {
            return _resourceCount;
        }

        public void IncrementResource() {
            _resourceCount++;
            OnValueChange.Invoke(this, _resourceCount, 1);
            // UpdateUI();
        }

        public void RemoveResource(int number) {
            if (!IsEnough(number)) {
                Debug.LogException(new Exception("Trying to take resource while it is not enough!"));
            }
            _resourceCount -= number;
            OnValueChange.Invoke(this, _resourceCount, number);
            // UpdateUI();
        }

        public int GetInitResource() {
            return _initCount;
        }
    }

}