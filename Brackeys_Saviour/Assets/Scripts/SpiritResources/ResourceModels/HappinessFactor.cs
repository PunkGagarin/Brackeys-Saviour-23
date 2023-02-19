namespace SpiritResources {

    public class HappinessFactor : BaseResource {

        public HappinessFactor(int startHappiness, int maxHap, SpiritResourceType type) {
            _maxRes = maxHap;
            _resourceCount = startHappiness;
            _type = type;
        }
    }

}