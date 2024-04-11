namespace Backrooms.World.Generation;

public class ChunkModel {
    private RoomModel [,] _rooms { get; set; }

    public ChunkModel (int x, int y) {
        _rooms = new RoomModel  [x, y];
    }

    public RoomModel this [int x, int y] {
        get {
            return _rooms [x, y];
        }
        set {
            _rooms [x, y] = value;
        }
    }
}