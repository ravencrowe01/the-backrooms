using Backrooms.Common.RNG;
using Backrooms.World.Generation;
using Godot;

namespace Backrooms.Managers.World;

internal partial class WorldManager : Node {
    [Export]
    private ChunkManager _chunkManager;

    public IChunkGenerator StartingChunkGenerator {
        private get {
            return default;
        }
        set {
            _chunkManager.StartingChunkGenerator = value;
        }
    }

    public ulong Seed { private get; set; }

    public override void _Ready () {
        _chunkManager.StartingChunkGenerator = StartingChunkGenerator;
    }

    public void GenerateStartingChunks () => _chunkManager.GenerateStartingChunk (new RNGProvider (Seed));

    private class RNGProvider : IRNGProvider {
        private RandomNumberGenerator rng;

        public RNGProvider (ulong seed) {
            rng = new RandomNumberGenerator {
                Seed = seed
            };
        }

        public int Next (int max) => rng.RandiRange (0, max);

        public void SetSeed (ulong seed) => rng.Seed = seed;
    }
}
