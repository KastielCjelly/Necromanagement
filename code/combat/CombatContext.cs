using System;
using System.Collections.Generic;
using Godot;
using Necromanagement.Characters;

namespace NecroManagement.Combat {
    public class CombatContext {
        public bool IsHero(Character character) {
            throw new NotImplementedException();
        }

        public List<Vector2> GetMoveDirections(Character character) {
            throw new NotImplementedException();
        }

        public List<Vector2> GetAttackDirections(Character character, CombatMove attack) {
            throw new NotImplementedException();
        }
    }
}