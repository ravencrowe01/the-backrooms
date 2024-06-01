using Backrooms.Common.RNG;
using Backrooms.Managers.World;
using Backrooms.Scripts.World.Generation.Generators;
using Backrooms.World.Generation;
using Godot;

namespace Backrooms.Managers;

internal partial class GameManager : Node {
    [Export]
    private PackedScene _worldManagerBase;
    private WorldManager _worldManager;

    public override void _Ready () {
        _worldManager = _worldManagerBase.Instantiate<WorldManager> ();
        AddChild (_worldManager);

        _worldManager.StartingChunkGenerator = new BacktrackingAlgorithim ();
        _worldManager.GenerateStartingChunks ();
    }

    private class TestChunkGenerator : IChunkGenerator {
        public ChunkModel GenerateChunk (Vector2 cords, Vector2 dimensions, IRNGProvider rng) {
            var model = new ChunkModel (cords, dimensions);

            for (int y = 0; y < dimensions.X; y++) {
                for (int x = 0; x < dimensions.Y; x++) {
                    var c = new Vector2 (y, x);

                    model [c] = new RoomModel (c) {
                        NorthWall = false,
                        SouthWall = false,
                        EastWall = false,
                        WestWall = false
                    };
                }
            }

            return model;
        }
    }
}
