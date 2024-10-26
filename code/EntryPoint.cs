using Godot;
using NecroManagement.DungeonBuilding;
using NecroManagement.Resources;

namespace NecroManagement.code {
    public class EntryPoint: Node2D {

        public override void _Ready() {
            var dungeon = new Dungeon(GetNode<TileMap>("TileMap"), new Wallet(), new Treasures());
        }
        
    }
}