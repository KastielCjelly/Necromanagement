using System;

namespace Necromanagement.Characters {
    public class Health {
        public event Action<Health> OnChanged;
        public bool IsAlive => Current > 0;
        public int Current { get; private set; }
        public int Max { get; private set; }

        public Health(int max) {
            Current = max;
            Max = max;
        }

        public void Damage(int amount) {
            Current = Math.Max(Current - amount, 0);
            OnChanged?.Invoke(this);
        }

        public void Heal(int amount) {
            Current = Math.Min(Current + amount, 0);
            OnChanged?.Invoke(this);
        }

        public void FullHeal() {
            Current = Max;
            OnChanged?.Invoke(this);
        }

        public void Upgrade(int newMax) {
            Max = newMax;
            Heal(0);
            OnChanged?.Invoke(this);
        }
    }
}