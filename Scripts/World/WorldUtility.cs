using Godot;

namespace Backrooms.World;

public static class WorldUtility {
    public static IEnumerable<Vector2> ConstructGrid (Vector2 dimensions, int xOffset = 0, int yOffset = 0) {
        var found = new List<Vector2> ();

        for (int x = xOffset; x < dimensions.X + xOffset; x++) {
            for (int y = yOffset; y < dimensions.Y + yOffset; y++) {
                found.Add (new Vector2 (x, y));
            }
        }

        return found;
    }
}
