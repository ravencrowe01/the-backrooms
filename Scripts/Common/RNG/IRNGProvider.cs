namespace Backrooms.Common.RNG;

public interface IRNGProvider {
    /// <summary>
    /// Reset the RNG provider with the given seed.
    /// </summary>
    /// <param name="seed"></param>
    void SetSeed (ulong seed);

    /// <summary>
    /// Get the next integer in the RNG sequence between 0 and <em>max, inclusive.</em>
    /// </summary>
    /// <param name="max">The inclusive max value.</param>
    /// <returns></returns>
    int Next (int max);
}
