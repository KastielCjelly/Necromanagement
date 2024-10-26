using System;
using System.Collections.Generic;
using NecroManagement.Inventories;

namespace NecroManagement.Resources {
    public class Treasures {
        public event Action<IEnumerable<Item>> OnTreasuresChanged;
        public IEnumerable<Item> Items => _items;
        private readonly List<Item> _items;

        public Item PopAt(int index) {
            var result = _items[index];
            _items.RemoveAt(index);
            OnTreasuresChanged?.Invoke(Items);
            return result;
        }

        public void Add(Item item) {
            _items.Add(item);
            OnTreasuresChanged?.Invoke(Items);
        }
    }
}