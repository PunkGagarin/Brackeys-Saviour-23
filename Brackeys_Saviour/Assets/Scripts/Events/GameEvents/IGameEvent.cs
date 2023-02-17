namespace Events.GameEvents {

    public interface IGameEvent {

        public void Apply();
        public void Reject();
        
    }

}