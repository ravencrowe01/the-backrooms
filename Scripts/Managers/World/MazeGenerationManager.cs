using Backrooms.World.Generation;

namespace Backrooms.Managers.World;

internal class MazeGenerationManager {
    private IEnumerable<IChunkGenerator> _generators = new List<IChunkGenerator> ();
}