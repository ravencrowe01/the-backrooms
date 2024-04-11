using Backrooms.Common;
using Godot;

namespace Backrooms.World;

public partial class RoomStructure : Node3D {
        [Export]
        public Direction Direction { get; set; }

        [Export]
        public bool StartState { get; private set;}

        public bool State { get; private set; } = false;

        public override void _Ready () {
            SetProcess (false);
        }

        public void ToggleState (bool state) {
            SetProcess (state);
            State = state;
        }
    }
