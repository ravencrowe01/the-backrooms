namespace Backrooms.World.Generation;

public interface IRNGProvider {
    void SetSeed (int seed);

    /// <summary>
    /// Get the next integer in the RNG sequence between 0 and <em>max.</em>
    /// </summary>
    /// <param name="max">The exclusive max value.</param>
    /// <returns></returns>
    int Next(int max);
}
