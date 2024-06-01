using Backrooms.Common;
using Backrooms.Common.RNG;
using Backrooms.World.Generation;
using Godot;

namespace Backrooms.Scripts.World.Generation.Generators;

public class BacktrackingAlgorithim : IChunkGenerator {
    public ChunkModel GenerateChunk (Vector2 cords, Vector2 dimensions, IRNGProvider rng) {
        var model = new ChunkModel (cords, dimensions);
        var visited = new List<VisitedRoom> ();

        var sX = rng.Next (dimensions.IntX ());
        var sY = rng.Next (dimensions.IntY ());

        var startVec = new Vector2 (sX, sY);

        var start = new VisitedRoom (model [startVec], null, model.FindRoomNeighbors (startVec).ToList ());

        visited.Add (start);

        var current = visited [0];

        while (visited.Count < model.Count) {
            while (current.UnvisitedNeighbors.Count == 0) {
                if (current.Previous is null) {
                    return model;
                }

                current = current.Previous;
            }

            var count = current.UnvisitedNeighbors.Count;

            var roll = rng.Next (count - 1);

            var nextRoom = current.UnvisitedNeighbors [roll];

            var next = new VisitedRoom (nextRoom, current, model.FindRoomNeighbors (nextRoom.Coordinates).ToList ());

            next.UnvisitedNeighbors.RemoveAll (r => visited.Any (v => v.Room == r));

            visited.Add (next);

            var needsRemovel = visited.Where (visit => visit.UnvisitedNeighbors.Contains (nextRoom));

            foreach (var v in needsRemovel) {
                v.UnvisitedNeighbors.Remove (nextRoom);
            }

            var nextCords = next.Room.Coordinates;
            var currentCords = current.Room.Coordinates;

            var dir = currentCords.DirectionTo (nextCords).ToDirection ();

            current.Room.SetWall (dir, false);

            next.Room.SetWall (dir.Opposite (), false);

            current = next;
        }

        return model;
    }

    private class VisitedRoom (RoomModel room, BacktrackingAlgorithim.VisitedRoom previous, List<RoomModel> unvisitedNeighbors) {
        public RoomModel Room { get; set; } = room;

        public VisitedRoom Previous { get; set; } = previous;

        public List<RoomModel> UnvisitedNeighbors { get; set; } = unvisitedNeighbors;
    }
}
