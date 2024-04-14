using Godot;

namespace Backrooms.World.Generation;

public class RoomModel {
    public Vector2 Coordinates { get; }

    public bool NorthWall { get; set; }
    public bool SouthWall { get; set; }
    public bool EastWall { get; set; }
    public bool WestWall { get; set; }

    public bool NorthEastCorner { get; set; }
    public bool NorthWestCorner { get; set; }
    public bool SoutEastCorner { get; set; }
    public bool SouthWestCorner { get; set; }

    public RoomModel (Vector2 cords) {
        Coordinates = cords;
    }

    public void SetWalls (bool north = false, bool south = false, bool east = false, bool west = false) {
        NorthWall = north;
        SouthWall = south;
        EastWall = east;
        WestWall = west;
    }

    public void SetCorners (bool northEast, bool northWest, bool southEast, bool southWest) {
        NorthEastCorner = northEast;
        NorthWestCorner = northWest;
        SoutEastCorner = southEast;
        SouthWestCorner = southWest;
    }
}
