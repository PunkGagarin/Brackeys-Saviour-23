namespace SpiritResources.ResourceModels {

    public class HappinessFactor : BaseResource {

        public HappinessFactor(int startHappiness, int maxHap, int minValue, SpiritResourceType type) {
            maxRes = maxHap;
            _resourceCount = startHappiness;
            _initCount = startHappiness;
            base.type = type;
            this.minValue = minValue;
        }
    }

}