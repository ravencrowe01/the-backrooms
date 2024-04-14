using Backrooms.World.Generation;
using System.Collections.Generic;

namespace Backrooms.Managers;

internal class MazeGenerationManager {
    private IEnumerable<IChunkGenerator> _generators = new List<IChunkGenerator> ();
}