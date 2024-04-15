using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Backrooms.World;

public static class WorldUtility {
    public static IEnumerable<Vector2> GetNeighborsOf (Vector2 of, IEnumerable<Vector2> map, float range = 1, NeighborSearchFlags flags = 0) {
        var neighbors = map.Where (current => Filter (of, range, flags, current));

        var list = neighbors.ToList ();

        return list;
    }

    private static bool Filter (Vector2 of, float range, NeighborSearchFlags flags, Vector2 current) {
        if (current == of) {
            return false;
        }

        var max = of.DistanceTo (new Vector2 (of.X + range, of.Y + range));

        var dis = current.DistanceTo (of);

        if (dis > max) {
            return false;
        }

        if (flags.HasFlag (NeighborSearchFlags.SameAxisOnly)) {
            if (!(current.X == of.X || current.Y == of.Y)) {
                return false;
            }
        }

        if (flags.HasFlag (NeighborSearchFlags.NotOnSameAxis)) {
            if (current.X == of.X || current.Y == of.Y) {
                return false;
            }
        }

        return true;
    }
}
