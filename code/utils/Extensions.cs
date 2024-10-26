using System;
using System.Collections.Generic;

namespace Necromanagement.Utils {
    public static class Extensions {
        public static List<T> Shuffle<T>(this List<T> self, Random random) {
            self.Sort((x, y) => random.Next(-1, 2));
            return self;
        }

        public static IEnumerable<T> ForEachPair<T>(this IEnumerable<T> self, Action<T, T> action) {
            using (var enumerator = self.GetEnumerator()) {
                if (!enumerator.MoveNext())
                    return self;
                var firstOfPair = enumerator.Current;
                while (enumerator.MoveNext()) {
                    action.Invoke(firstOfPair, enumerator.Current);
                    firstOfPair = enumerator.Current;
                }
            }

            return self;
        }
    }
}