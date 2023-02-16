using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Assertions;

namespace SpiritResources {

    public class ResourceManager : MonoBehaviour {

        private Dictionary<SpiritResourceType, BaseResource> _resources;

        [SerializeField]
        private ResourcePanelUI _resourcePanelUI;

        [SerializeField]
        private HappinessView _happinessView;

        private void Awake() {
            _resourcePanelUI = GetComponent<ResourcePanelUI>();
            _happinessView = GetComponent<HappinessView>();
            
            Assert.IsNotNull(_resourcePanelUI);
            Assert.IsNotNull(_happinessView);

            _resources.Add(SpiritResourceType.Money, new SpiritResource(_resourcePanelUI, SpiritResourceType.Money));
            _resources.Add(SpiritResourceType.Volunteers, new SpiritResource(_resourcePanelUI, SpiritResourceType.Volunteers));
            _resources.Add(SpiritResourceType.Happiness, new HappinessFactor(_happinessView, 15, SpiritResourceType.Happiness ));
        }

        public bool IsEnoughResource(SpiritResourceType type, int number) {
            return _resources[type].IsEnough(number);
        }

        public void TakeResource(SpiritResourceType type, int number) {
            _resources[type].TakeResource(number);
        }
        
        public void AddResource(SpiritResourceType type, int number) {
            _resources[type].AddResource(number);
        }
    }

}