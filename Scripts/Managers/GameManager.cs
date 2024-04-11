using Godot;

namespace Backrooms.Managers;

public partial class GameManager : Node {
    [Export]
    private PackedScene _gameWorldManager;

    public override void _Ready()
    {
        base._Ready();
    }
}
