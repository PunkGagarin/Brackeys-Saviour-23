using System;
using System.Collections.Generic;
using Events.GameEvents;
using UnityEngine;
using Random = System.Random;

namespace Events.Pools {

    public abstract class BasePool<TE> where TE : BaseGameEvent {


        protected List<TE> _events;

        public void InitPool(List<TE> events) {
            _events = events;
        }

        public abstract void InitPool();

        public TE GetRandomPoolEvent() {
            if (_events.Count <= 0) {
                Debug.LogException(new Exception("There is no events in pool, probably Init is wrong"));
            }
            return _events[new Random().Next(_events.Count)];
        }

    }

}