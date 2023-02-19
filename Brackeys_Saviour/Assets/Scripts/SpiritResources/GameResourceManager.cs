using System;
using System.Collections.Generic;
using Events.UI;
using ModestTree;
using SpiritResources.ResourceModels;
using UnityEngine;
using Zenject;

namespace SpiritResources {

    public class GameResourceManager : MonoBehaviour {

        private readonly Dictionary<SpiritResourceType, BaseResource> _resources = new();

        private readonly Dictionary<SpiritResourceType, ResourceView> _views = new();

        [Inject]
        private GameEventUI _eventView;

        [SerializeField]
        private MoneyView _moneyView;

        [SerializeField]
        private VolunteersView _volunteersView;

        [SerializeField]
        private HappinessView _happinessView;

        public Action<SpiritResourceType> OnMinValueReach = delegate { };
        
        public Action<SpiritResourceType> OnMaxValueReach = delegate { };

        private void Awake() {
            Assert.IsNotNull(_moneyView);
            Assert.IsNotNull(_volunteersView);
            Assert.IsNotNull(_happinessView);

            _views.Add(SpiritResourceType.Money, _moneyView);
            _views.Add(SpiritResourceType.Volunteers, _volunteersView);
            _views.Add(SpiritResourceType.Happiness, _happinessView);

            _resources.Add(SpiritResourceType.Money, new SpiritResource(20, 10000, -50, SpiritResourceType.Money));
            _resources.Add(SpiritResourceType.Volunteers, new SpiritResource(4, 10, -5, SpiritResourceType.Volunteers));
            _resources.Add(SpiritResourceType.Happiness, new HappinessFactor(35, 100, 0, SpiritResourceType.Happiness));

            Assert.IsEqual(_resources.Count, _views.Count, "Not equal resource-view count!!!");

            foreach (var resource in _resources) {
                resource.Value.OnValueChange += _views[resource.Key].UpdateResourceUI;
                resource.Value.OnValueChange += CheckForBottomValue;
                _views[resource.Key].InitView(resource.Value.GetCurrentResource());
            }

            _eventView.OnResourceTagInput += HandleResourceChange;
        }

        private void CheckForBottomValue(BaseResource baseResource, int currentValue, int arg3) {
            if (currentValue <= baseResource.minValue) {
                OnMinValueReach.Invoke(baseResource.type);
            } else if(currentValue >= baseResource.maxRes){
                OnMaxValueReach.Invoke(baseResource.type);
            }
        }

        private void HandleResourceChange(SpiritResourceType type, int value) {
            //due to specific ink work we can have -10 or 10, so in both ways we can call only Add func
            AddResource(type, value);
        }

        public bool IsEnoughResource(SpiritResourceType type, int number) {
            return _resources[type].IsEnough(number);
        }

        public void RemoveResource(SpiritResourceType type, int number) {
            _resources[type].RemoveResource(number);
        }

        public void AddResource(SpiritResourceType type, int number) {
            _resources[type].AddResource(number);
        }

        public int GetCurrentResource(SpiritResourceType type) {
            return _resources[type].GetCurrentResource();
        }

        public int GetInitResource(SpiritResourceType type) {
            return _resources[type].GetInitResource();
        }
    }

}