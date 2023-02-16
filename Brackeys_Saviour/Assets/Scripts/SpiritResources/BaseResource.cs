using System;
using UnityEngine;

namespace SpiritResources {

    [Serializable]
    public abstract class BaseResource {

        [SerializeField]
        protected int _resourceCount;
        
        
        [SerializeField]
        protected SpiritResourceType _type;

        public bool IsEnough(int number) {
            return _resourceCount >= number;
        }

        public void AddResource(int number) {
            _resourceCount += number;
            UpdateUI();
        }

        public void IncrementResource() {
            _resourceCount++;
            UpdateUI();
        }

        public void TakeResource(int number) {
            if (!IsEnough(number)) {
                Debug.LogException(new Exception("Trying to take resource while it is not enough!"));
            }
            _resourceCount -= number;
            UpdateUI();
        }

        protected abstract void UpdateUI();
    }

}