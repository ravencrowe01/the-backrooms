using Godot;

namespace Backrooms.World.Generation;

public class ChunkModel {
    public Vector2 Coordinates { get; }

    public Vector2 Dimensions { get; }

    private Dictionary<Vector2, RoomModel> _rooms = new Dictionary<Vector2, RoomModel> ();

    public int Count => _rooms.Keys.Count;

    public ChunkModel (Vector2 cords, Vector2 dims) {
        Coordinates = cords;
        Dimensions = dims;

        SetupRooms ();
    }

    private void SetupRooms () {
        for (int x = 0; x < Dimensions.X; x++) {
            for (int y = 0; y < Dimensions.Y; y++) {
                var cords = new Vector2 (x, y);

                _rooms.Add (cords, new RoomModel (cords));
            }
        }
    }

    public RoomModel this [Vector2 vec] {
        get {
            return _rooms [vec];
        }
        set {
            _rooms [vec] = value;
        }
    }

    public IEnumerable<RoomModel> FilterRooms (Func<RoomModel, bool> filters) => _rooms.Values.Where (filters);

    public IEnumerable<RoomModel> FindRoomNeighbors (Vector2 of, bool diagonal = false) => FilterRooms (room => {
        var x = room.Coordinates.X - of.X;
        var y = room.Coordinates.Y - of.Y;

        var dist = Mathf.Sqrt (x * x + y * y);

        var distMax = diagonal ? 1 : Mathf.Sqrt2;

        return dist <= distMax;
    });
}