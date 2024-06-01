using Godot;

namespace Backrooms.World;

public partial class Zone : Node3D {
    [Export]
    private Room _roomScene;
    [Export]
    private Node _chunkScene;

    private Dictionary<Vector2, Chunk> _chunks = new Dictionary<Vector2, Chunk> ();

    public void AddChunk (Chunk chunk) => _chunks.TryAdd (chunk.ChunkPosition, chunk);
}
