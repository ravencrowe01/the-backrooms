using Backrooms.Common;
using Backrooms.Common.RNG;
using Backrooms.World.Generation;
using Godot;
using System.Collections.Generic;

namespace Backrooms.Scripts.World.Generation.Generators {
    public class BacktrackingAlgorithim : IChunkGenerator {
        public ChunkModel GenerateChunk (Vector2 cords, Vector2 dimensions, IRNGProvider rng) {
            var model = new ChunkModel (cords, dimensions);
            var visited = new List<VisitedRoom> ();

            var sX = rng.Next (dimensions.IntX ());
            var sY = rng.Next (dimensions.IntY ());

            var startVec = new Vector2 (sX, sY);

            var start = model [startVec];

            visited.Add (new VisitedRoom {
                Previous = null,
                UnvisitedNeighbors = model.Neighbors (startVec)
            });

            return model;
        }

        private class VisitedRoom {
            public VisitedRoom Previous { get; set; }

            public IEnumerable<RoomModel> UnvisitedNeighbors { get; set; }
        }
    }
}
