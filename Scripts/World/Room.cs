using Backrooms.Common;
using Backrooms.World.Generation;
using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Backrooms.World;

public partial class Room : Node3D {
    [Export]
    private RoomStructure [] _walls;

    [Export]
    private RoomStructure [] _corners;

    public Vector2 LocalPosition { get; set; }
    public Vector2 WorldPosition { get; set; }

    public void SetupRoom (RoomModel model) {
        SetWalls (model.NorthWall, model.SouthWall, model.EastWall, model.WestWall);
        SetCorners (model.NorthEastCorner, model.NorthWestCorner, model.SoutEastCorner, model.SouthWestCorner);
    }

    public void SetWalls (bool north = false, bool south = false, bool east = false, bool west = false) {
        FindWall (Direction.North).SetState (north);
        FindWall (Direction.South).SetState (south);
        FindWall (Direction.East).SetState (east);
        FindWall (Direction.West).SetState (west);

        RoomStructure FindWall (Direction dir) => _walls.FirstOrDefault (wall => wall.Direction == dir);
    }

    public void SetWalls (Dictionary<Direction, bool> walls) {
        foreach (var dir in walls.Keys) {
            if (dir <= Direction.West) {
                _walls.First (wall => wall.Direction == dir).SetState (walls [dir]);
            }
        }
    }

    public void SetCorners (bool northEast = false, bool northWest = false, bool southEast = false, bool southWest = false) {
        FindCorner (Direction.NorthEast).SetState (northEast);
        FindCorner (Direction.NorthWest).SetState (northWest);
        FindCorner (Direction.SouthEast).SetState (southEast);
        FindCorner (Direction.SouthWest).SetState (southWest);

        RoomStructure FindCorner (Direction dir) => _corners.First (corner => corner.Direction == dir);
    }

    public void SetCorners (Dictionary<Direction, bool> corners) {
        foreach (var dir in corners.Keys) {
            if (dir > Direction.West) {
                _corners.First (corner => corner.Direction == dir).SetState (corners [dir]);
            }
        }
    }
}
