using Backrooms.Common;
using Backrooms.Common.RNG;
using Backrooms.World;
using Backrooms.World.Generation;
using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Backrooms.Scripts.World.Generation.Generators;

public class BacktrackingAlgorithim : IChunkGenerator {
    public ChunkModel GenerateChunk (Vector2 cords, Vector2 dimensions, IRNGProvider rng) {
        var model = new ChunkModel (cords, dimensions);
        var visited = new List<VisitedRoom> ();

        var sX = rng.Next (dimensions.IntX ()) - 1;
        var sY = rng.Next (dimensions.IntY ()) - 1;

        var startVec = new Vector2 (sX, sY);

        var start = new VisitedRoom {
            Room = model [startVec],
            Previous = null,
            UnvisitedNeighbors = model.FindNeighbors (startVec, NeighborSearchFlags.SameAxisOnly).ToList ()
        };

        visited.Add (start);

        var current = visited [0];

        while (visited.Count < model.Count) {
            while (!current.UnvisitedNeighbors.Any ()) {
                if(current.Previous is null) {
                    return model;
                }

                current = current.Previous;
            }

            var count = current.UnvisitedNeighbors.Count;

            var roll = rng.Next (count - 1);

            var nextRoom = current.UnvisitedNeighbors [roll];

            var next = BuildVisitedRoom (model, current, nextRoom);

            next.UnvisitedNeighbors.RemoveAll (r => visited.Any(v => v.Room == r));

            visited.Add (next);

            var needsRemovel = visited.Where (visit => visit.UnvisitedNeighbors.Contains(nextRoom));

            foreach (var v in needsRemovel) {
                v.UnvisitedNeighbors.Remove(nextRoom);
            }

            var nextCords = next.Room.Coordinates;
            var currentCords = current.Room.Coordinates;

            var dir = currentCords.DirectionTo (nextCords).ToDirection();

            current.Room.SetWall (dir, false);

            next.Room.SetWall (dir.Opposite (), false);

            current = next;
        }

        return model;
    }

    private static VisitedRoom BuildVisitedRoom (ChunkModel model, VisitedRoom current, RoomModel nextRoom) {
        return new VisitedRoom {
            Room = nextRoom,
            Previous = current,
            UnvisitedNeighbors = model.FindNeighbors (nextRoom.Coordinates, NeighborSearchFlags.SameAxisOnly).ToList ()
        };
    }

    private class VisitedRoom {
        public RoomModel Room { get; set; }

        public VisitedRoom Previous { get; set; }

        public List<RoomModel> UnvisitedNeighbors { get; set; }
    }
}
