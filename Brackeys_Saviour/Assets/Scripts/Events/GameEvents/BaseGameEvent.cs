using UnityEngine;
using EventType = Events.Types.EventType;

namespace Events.GameEvents {


    public abstract class BaseGameEvent : ScriptableObject, IGameEvent {

        [field: SerializeField]
        public EventType eventType { get; private set; }

        [field: SerializeField]
        [field: TextArea(5, 20)]
        public string gameEventText { get; protected set; }

        [field: SerializeField]
        public string acceptButtonText { get; protected set; }

        [field: SerializeField]
        public string rejectButtonText { get; protected set; }

        [field: SerializeField]
        [field: TextArea(5, 20)]
        public string acceptedText { get; protected set; }

        [field: SerializeField]
        [field: TextArea(5, 20)]
        public string rejectedText { get; protected set; }

        [SerializeField]
        private EventReactionType _reactionType;

        // [SerializeField]
        //todo: for future random weight pickup
        // private int _weight;

        public abstract void Apply();

        public abstract void Reject();
    }

    public enum EventReactionType {
        MiniGame,
        Dialogue,
        Timer,
        
    }
}