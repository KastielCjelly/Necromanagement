using System;
using System.Net.Security;
using Necromanagement.Characters;

namespace NecroManagement.Combat {
    public class Turn {
        public bool IsCurrent { get; private set; } = false;
        private Turn _next;
        private readonly Round _round;
        private readonly Character _actor;

        public Turn(Round round, Character actor) {
            _round = round;
            _actor = actor;
        }

        public void End() {
            if (!IsCurrent)
                return;
            IsCurrent = false;
            if (_next == null) {
                _round.End();
                return;
            }
            _next.Start();
        }

        protected internal Turn Then(Turn next) {
            if (_next != null)
                throw new InvalidOperationException("Next turn is already defined");
            _next = next;
            return _next;
        }

        protected internal void Start() {
            if (!_actor.Health.IsAlive)
                End();
            IsCurrent = true;
        }
    }
}