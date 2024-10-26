using System.Collections.Generic;
using System.Linq;
using Godot;
using Necromanagement.GlobalStuff;
using NecroManagement.Resources;

namespace NecroManagement.DungeonBuilding {
    public class Dungeon: Node2D {
        public static Dungeon Instance { get; private set; }
        public readonly TileMap Walls;
        public readonly Wallet Wallet;
        public readonly Treasures Treasures;
        public IEnumerator<Room> Rooms => _rooms.GetEnumerator();
        private readonly List<Room> _rooms = new List<Room>();
        private readonly RoomGenerator _generator = new RoomGenerator();

        public Dungeon(TileMap walls, Wallet wallet, Treasures treasures) {
            Wallet = wallet;
            Walls = walls;
            Treasures = treasures;
            Instance = this;
        }

        public void BuildRoom() {
            var last = _rooms.Last();
            var pos = last.Position + last.Size * Vector2.Right + Vector2.Right;
            var room = _generator.GenNewRoom(pos);
            _rooms.Add(room);
            for (var x = (int)room.Position.x; x < room.Size.x; x++) {
                for (var y = (int)room.Position.y; y < room.Size.y; y++) {
                    Walls.SetCell(x, y, MagicConstants.ROOM_CELL);
                }
            }
            room.Fill((x) => Walls.MapToWorld(x));
        }
    }
}