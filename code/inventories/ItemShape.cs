using System.Collections.Generic;
using System.Linq;
using Godot;

namespace NecroManagement.Inventories {
    public class ItemShape {
        public readonly Vector2 Alignment;
        public IEnumerable<Vector2> Parts => _parts;
        private List<Vector2> _parts;

        public void Rotate() {
            _parts = _parts.Select((x) => x.Rotated(Mathf.Pi / 2)).ToList();
        }
    }
}