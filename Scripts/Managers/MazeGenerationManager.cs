namespace Backrooms.Managers;

public class MazeGenerationManager {
    private IEnumerable<IMazeGenerator> generators = new List<IMazeGenerator> ();
}

public interface IMazeGenerator {
    
}