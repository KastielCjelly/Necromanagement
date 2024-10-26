using System;

namespace Necromanagement.Characters {
      public class Character {
            public Stats OriginalStats { get; private set; }
            public MutableStats CurrentStats { get; private set; }
            public Body Body { get; private set; }
            public Health Health { get; private set; }

            public void InsertTo(Body body) {
                  if (Body != null)
                        throw new InvalidOperationException("This character already has body");
                  Body = body;
            }

            public void RecalculateBonuses() {
                  CurrentStats = OriginalStats.Copy();
                  // Тут ещё всякий код
                  Health.Upgrade(CurrentStats.Vitality);
                  Health.FullHeal();
            }
      }
}