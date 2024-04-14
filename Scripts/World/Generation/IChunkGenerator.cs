using Backrooms.Common.RNG;
using Godot;

namespace Backrooms.World.Generation;

public interface IChunkGenerator {
    ChunkModel GenerateChunk (Vector2 cords, Vector2 dimensions, IRNGProvider rng);
}
