namespace SpiritResources {

    public class HappinessFactor : BaseResource {

        private readonly HappinessView _happinessView;

        public HappinessFactor(HappinessView happinessView, int startHappiness, SpiritResourceType type) {
            _happinessView = happinessView;
            _resourceCount = startHappiness;
            _type = type;
            UpdateUI();
        }
        
        protected override void UpdateUI() {
            _happinessView.UpdateHappiness(_resourceCount);
        }
    }

}