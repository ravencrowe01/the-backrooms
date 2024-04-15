using System.Collections.Generic;
using Backrooms.Common.RNG;
using Backrooms.World;
using Backrooms.World.Generation;
using Godot;

namespace Backrooms.Managers;

internal partial class ChunkManager : Node {
    private Dictionary<Vector2, Chunk> _chunks = new Dictionary<Vector2, Chunk> ();

    [Export]
    private PackedScene _roomBase;

    [Export]
    private PackedScene _chunkBase;

    [Export]
    private Vector2I _chunkDimensions;

    [Export]
    private Vector2I _roomDimensions;

    public IChunkGenerator StartingChunkGenerator { private get; set; }

    public void GenerateStartingChunk (IRNGProvider rng) {
        var cords = new Vector2 (0, 0);

        var model = StartingChunkGenerator.GenerateChunk (cords, _chunkDimensions, rng);

        var chunk = _chunkBase.Instantiate<Chunk> ();

        chunk.SetupChunk (model, cords, _roomBase);

        chunk.Position += CalculateChunkOffset ();

        AddChild (chunk);

        _chunks.Add (cords, chunk);
    }

    private Vector3 CalculateChunkOffset () => -new Vector3 ((_chunkDimensions.X / 2 * _roomDimensions.X) - (_roomDimensions.X / 2), 0, (_chunkDimensions.Y / 2* _roomDimensions.Y) - (_roomDimensions.Y / 2));
}
