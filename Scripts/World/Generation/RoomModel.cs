using Backrooms.Common;
using Godot;

namespace Backrooms.World.Generation;

public class RoomModel (Vector2 cords) {
    public Vector2 Coordinates { get; } = cords;

    public bool NorthWall { get; set; } = true;
    public bool SouthWall { get; set; } = true;
    public bool EastWall { get; set; } = true;
    public bool WestWall { get; set; } = true;

    public bool NorthEastCorner { get; set; }
    public bool NorthWestCorner { get; set; }
    public bool SouthEastCorner { get; set; }
    public bool SouthWestCorner { get; set; }

    public void SetWalls (bool north = false, bool south = false, bool east = false, bool west = false) {
        NorthWall = north;
        SouthWall = south;
        EastWall = east;
        WestWall = west;
    }

    public void SetWall (Direction dir, bool state) {
        switch (dir) {
            case Direction.North:
                NorthWall = state;
                break;
            case Direction.South:
                SouthWall = state;
                break;
            case Direction.East:
                EastWall = state;
                break;
            case Direction.West:
                WestWall = state;
                break;
            case Direction.NorthEast:
            case Direction.NorthWest:
            case Direction.SouthEast:
            case Direction.SouthWest:
                break;
        }
    }

    public void SetCorners (bool northEast = false, bool northWest = false, bool southEast = false, bool southWest = false) {
        NorthEastCorner = northEast;
        NorthWestCorner = northWest;
        SouthEastCorner = southEast;
        SouthWestCorner = southWest;
    }

    public void SetCorner (Direction dir, bool state) {
        switch (dir) {
            case Direction.North:
            case Direction.South:
            case Direction.East:
            case Direction.West:
                break;
            case Direction.NorthEast:
                NorthEastCorner = state;
                break;
            case Direction.NorthWest:
                NorthWestCorner = state;
                break;
            case Direction.SouthEast:
                SouthEastCorner = state;
                break;
            case Direction.SouthWest:
                SouthWestCorner = state;
                break;
        }
    }
}
