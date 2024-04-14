using Backrooms.Common.RNG;
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

        _worldManager.StartingChunkGenerator = new TestChunkGenerator ();
        _worldManager.GenerateStartingChunks ();
    }

    private class TestChunkGenerator : IChunkGenerator {
        public ChunkModel GenerateChunk (Vector2 cords, Vector2 dimensions, IRNGProvider rng) {
            var model = new ChunkModel (cords, dimensions);

            for(int x = 0; x < dimensions.X; x++) {
                for(int y = 0; y < dimensions.Y; y++) {
                    var c = new Vector2 (x, y);

                    model [c] = new RoomModel (c) {
                        NorthWall = rng.Next (1) == 1,
                        SouthWall = rng.Next (1) == 1,
                        EastWall = rng.Next (1) == 1,
                        WestWall = rng.Next (1) == 1
                    };
                }
            }

            return model;
        }
    }
}
