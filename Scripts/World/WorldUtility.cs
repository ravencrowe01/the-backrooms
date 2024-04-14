using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Backrooms.World;

public static class WorldUtility {
    public static IEnumerable<Vector2> GetNeighbors (Vector2 of, IEnumerable<Vector2> map, float range = 1, NeighborSearchFlags flags = 0) {
        var neighbors = map.Where (current => {
            var max = current.DistanceTo (new Vector2 (range, range));

            var dis = current.DistanceTo (of);

            if (dis > max) {
                return false;
            }

            if (flags.HasFlag (NeighborSearchFlags.SameAxisOnly)) {
                if (!(current.X == 0 || current.Y == 0)) {
                    return false;
                }
            }

            if (flags.HasFlag (NeighborSearchFlags.NotOnSameAxis)) {
                if (current.X == 0 || current.Y == 0) {
                    return false;
                }
            }

            return true;
        });

        return neighbors;
    }
}
