using Backrooms.Common;
using Godot;

namespace Backrooms.World;

public partial class RoomStructure : Node3D {
    [Export]
    public Direction Direction { get; set; }

    [Export]
    public bool StartState { get; private set; }

    public bool State { get; private set; } = false;

    public void SetState (bool state) {
        SetProcess (state);
        Visible = state;
        State = state;
    }
}
