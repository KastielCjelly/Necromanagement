using System;
using System.Drawing.Drawing2D;
using Godot;

namespace NecroManagement.DungeonBuilding {
    public class Room {
        public readonly Vector2 Position;
        public readonly Vector2 Size;

        public Room(Vector2 position, Vector2 size) {
            Position = position;
            Size = size;
        }

        public void Fill(Func<Vector2, Vector2> coordinateMapper) {
            
        }
    }
}