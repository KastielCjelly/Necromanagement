using System;
using System.Collections.Generic;
using System.Linq;
using Necromanagement.Characters;
using Necromanagement.Utils;

namespace NecroManagement.Combat {
    public class Round {
        public Action<Round, List<Character>> OnEnded;
        private readonly List<Character> _combatants;

        public Round(List<Character> combatants) {
            _combatants = combatants;
        }

        protected internal void Start() 
            => _combatants
                .Select((x) => new Turn(this, x))
                .ForEachPair((x, y) => x.Then(y))
                .FirstOrDefault(null)?.Start();

        protected internal void End() {
            OnEnded?.Invoke(this, _combatants.Where((x) => x.Health.IsAlive).ToList());
        }
    }
}