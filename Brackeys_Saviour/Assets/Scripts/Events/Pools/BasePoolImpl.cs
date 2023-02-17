using System.Linq;
using Events.GameEvents;

namespace Events.Pools {

    public class BasePoolImpl : BasePool<BaseGameEvent> {
        public override void InitPool() {
            _events = UnityEngine.Resources.LoadAll<BaseGameEvent>("Events/Time").ToList();
        }
    }

}