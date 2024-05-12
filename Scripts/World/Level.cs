using Godot;

namespace Backrooms.World;

public partial class Level : Node3D {
    [Export]
    private Room _roomScene;
    [Export]
    private Node _chunkScene;

    private Dictionary<Vector2, Chunk> _chunks = new Dictionary<Vector2, Chunk> ();

    private bool _isWorldSetup = false;

    public override void _Ready () {

    }

    public void SetupWorld () {
        if (_isWorldSetup) {
            return;
        }
    }

    public void GenerateChunk (Vector2 cords) {

    }
}
