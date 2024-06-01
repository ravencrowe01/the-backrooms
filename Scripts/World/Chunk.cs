using Backrooms.Common;
using Backrooms.World.Generation;
using Godot;

namespace Backrooms.World;

public partial class Chunk : Node3D {
    public Vector2 ChunkPosition { get; private set; }

    public Room [,] Rooms { get; private set; }

    public void SetupChunk (ChunkModel model, Vector2 position, PackedScene roomBase) {
        ChunkPosition = position;
        Rooms = new Room [model.Dimensions.IntX (), model.Dimensions.IntY ()];

        for (int y = 0; y < Rooms.GetLength (0); y++) {
            for (int x = 0; x < Rooms.GetLength (1); x++) {
                var localPos = new Vector2 (y, x);
                //var worldPos = new Vector2 (ChunkPosition.X * Constants.ChunkWidth + y, ChunkPosition.Y * Constants.ChunkHeight + x);

                var room = roomBase.Instantiate<Room> ();

                room.Coordinates = localPos;
                room.Position = new Vector3 (x * Constants.RoomWidth, 0, y * Constants.RoomHeight);
                room.SetupRoom (model [localPos]);
                room.Name = $"{x},{y}";

                Rooms [y, x] = room;

                AddChild (room);
            }
        }
    }

    public void ToggleRoomWalls (int x, int y, bool north = false, bool south = false, bool east = false, bool west = false) => Rooms [x, y].SetWalls (north, south, east, west);

    public void ToggleRoomCorners (int x, int y, bool northEast = false, bool northWest = false, bool southEast = false, bool southWest = false) => Rooms [x, y].SetWalls (northEast, northWest, southEast, southWest);
}
