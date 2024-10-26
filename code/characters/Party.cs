using System.Collections.Generic;
using System.Linq;

namespace Necromanagement.Characters {
    public class Party {
        public bool IsAlive => Characters.Any(x => x.Health.IsAlive);
        public List<Character> Characters { get; private set; }
    }
}