namespace Backrooms.World.Generation;

public interface IChunkGenerator {
    ChunkModel GenerateChunk (int x, int y);
}
