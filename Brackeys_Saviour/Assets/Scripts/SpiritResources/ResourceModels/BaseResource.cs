using System;
using UnityEngine;

namespace SpiritResources {

    [Serializable]
    public abstract class BaseResource {

        public Action<int, int> OnValueChange = delegate { };

        [SerializeField]
        protected int _resourceCount;

        [SerializeField]
        protected int _maxRes;

        [SerializeField]
        protected SpiritResourceType _type;

        public bool IsEnough(int number) {
            return _resourceCount >= number;
        }

        public void AddResource(int number) {
            _resourceCount += number;
            OnValueChange.Invoke(_resourceCount, number);
        }

        public int GetCurrentResource() {
            return _resourceCount;
        }

        public void IncrementResource() {
            _resourceCount++;
            OnValueChange.Invoke(_resourceCount, 1);
            // UpdateUI();
        }

        public void RemoveResource(int number) {
            if (!IsEnough(number)) {
                Debug.LogException(new Exception("Trying to take resource while it is not enough!"));
            }
            _resourceCount -= number;
            OnValueChange.Invoke(_resourceCount, number);
            // UpdateUI();
        }
    }

}