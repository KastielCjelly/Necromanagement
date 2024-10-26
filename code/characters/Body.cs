using System;
using Godot;

namespace Necromanagement.Characters {
    public class Body: KinematicBody2D {
        public Character Character { get; private set; }

        public void Insert(Character character) {
            if (Character != null)
                throw new InvalidOperationException("This body already has character");
            Character = character;
        }
    }
}