using System;
using System.Collections.Generic;
using System.Linq;
using Necromanagement.Characters;
using Necromanagement.GlobalStuff;
using Necromanagement.Utils;

namespace NecroManagement.Combat {
    public class Fight {
        public Action<bool> OnEnded;
        private Party _heroes;
        private Party _mobs;
        private CombatContext _context;

        public void Start() {
            Continue(null, _heroes.Characters.Concat(_mobs.Characters).ToList());
        }

        private void Continue(Round round, List<Character> combatants) {
            var flag = true;
            if (!(_heroes.IsAlive && _mobs.IsAlive)) {
                OnEnded?.Invoke(_heroes.IsAlive);
                flag = false;
            }
            if (round != null)
                round.OnEnded -= Continue;
            if (flag) {
                new Round(combatants.Shuffle(GlobalRandom.Instance)).OnEnded += Continue;
                round.Start();
            }

        }
    }
}