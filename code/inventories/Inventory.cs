using System.Collections.Generic;
using Godot;

namespace NecroManagement.Inventories {
    public class Inventory {
        public readonly Vector2 Size;
        public readonly Item[,] Grid;
        public IEnumerable<Item> Items => _items;
        private readonly List<Item> _items = new List<Item>();

        public bool TryInsert(Vector2 pos, Item item) {
            var origin = pos + item.Shape.Alignment;
            foreach (var part in item.Shape.Parts) {
                var partPos = part + origin;
                if (!Fit(partPos) || Grid[(int)partPos.y, (int)partPos.x] != null)
                    return false;
            }

            foreach (var part in item.Shape.Parts) {
                var partPos = part + origin;
                Grid[(int)partPos.y, (int)partPos.x] = item;
            }
            _items.Add(item);
            return true;
        }

        public Item PopFrom(Vector2 pos) {
            var item = Grid[(int)pos.y, (int)pos.x];
            if (item == null)
                return null;
            var origin = pos + item.Shape.Alignment;
            foreach (var part in item.Shape.Parts) {
                var partPos = part + origin;
                Grid[(int)partPos.y, (int)partPos.x] = null;
            }

            _items.Remove(item);
            return item;
        }

        private bool Fit(Vector2 pos) {
            if (pos.x < 0 || pos.y < 0)
                return false;
            if (pos.x >= Size.x || pos.y >= Size.y)
                return false;
            return true;
        }
    }
}