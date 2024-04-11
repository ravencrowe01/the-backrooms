using System.Collections.Generic;
using Backrooms.World;
using Godot;

namespace Backrooms.Managers;

public partial class WorldManager : Node {
    private Dictionary<Vector2, Chunk> _chunks = new Dictionary<Vector2, Chunk>();

    [Export]
    private PackedScene _roomBase;

    public PackedScene Roombase => _roomBase;

    [Export]
    private PackedScene _chunkBase;

    public PackedScene Chunkbase => _chunkBase;

    [Export]
    private Vector2 _chunkDimensions;

    [Export]
    private Vector2 _roomDimensions;

    public void GenerateStartingChunks () {
        
    }
}
