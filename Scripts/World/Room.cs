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
        FindWall (Direction.North).ToggleState (north);
        FindWall (Direction.South).ToggleState (south);
        FindWall (Direction.East).ToggleState (east);
        FindWall (Direction.West).ToggleState (west);

        RoomStructure FindWall (Direction dir) => _walls.FirstOrDefault (wall => wall.Direction == dir);
    }

    public void SetWalls (Dictionary<Direction, bool> walls) {
        foreach (var dir in walls.Keys) {
            if (dir <= Direction.West) {
                _walls.First (wall => wall.Direction == dir).ToggleState (walls [dir]);
            }
        }
    }

    public void SetCorners (bool northEast = false, bool northWest = false, bool southEast = false, bool southWest = false) {
        FindCorner (Direction.NorthEast).ToggleState (northEast);
        FindCorner (Direction.NorthWest).ToggleState (northWest);
        FindCorner (Direction.SouthEast).ToggleState (southEast);
        FindCorner (Direction.SouthWest).ToggleState (southWest);

        RoomStructure FindCorner (Direction dir) => _corners.First (corner => corner.Direction == dir);
    }

    public void SetCorners (Dictionary<Direction, bool> corners) {
        foreach (var dir in corners.Keys) {
            if (dir > Direction.West) {
                _corners.First (corner => corner.Direction == dir).ToggleState (corners [dir]);
            }
        }
    }
}
