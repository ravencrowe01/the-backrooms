using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Backrooms.World;

public static class WorldUtility {
    public static IEnumerable<Vector2> FindNeighbors (Vector2 of, Vector2 dimensions, int range = 1, NeighborSearchFlags flags = NeighborSearchFlags.None) {
        var found = new List<Vector2> ();

        for (int y = -range; y <= range; y++) {
            for (int x = -range; x <= range; x++) {
                var current = of - new Vector2 (x, y);

                if (!ShouldFilter (current, of, dimensions, flags)) {
                    found.Add (current);
                }
            }
        }

        return found;
    }

    private static bool ShouldFilter (Vector2 current, Vector2 relative, Vector2 dimensions, NeighborSearchFlags flags) {
        if (current == relative) {
            return true;
        }

        if (current.X < 0 || current.X >= dimensions.X || current.Y < 0 || current.Y >= dimensions.Y) {
            return true;
        }

        if (flags.HasFlag (NeighborSearchFlags.SameAxisOnly)) {
            if (!(current.X == relative.X || current.Y == relative.Y)) {
                return true;
            }
        }

        if (flags.HasFlag (NeighborSearchFlags.NotOnSameAxis)) {
            if (current.X == relative.X || current.Y == relative.Y) {
                return true;
            }
        }

        return false;
    }
}
