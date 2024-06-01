using Godot;

namespace Backrooms.Common;

public static class Vector2Extensions {
    public static int IntX (this Vector2 vec) => (int) vec.X;

    public static int IntY (this Vector2 vec) => (int) vec.Y;

    public static Direction ToDirection (this Vector2 vec) => new Dictionary<Vector2, Direction> {
        { Vector2.Down, Direction.North },
        { Vector2.Up, Direction.South },
        { Vector2.Right, Direction.East },
        { Vector2.Left, Direction.West }
    } [vec.Normalized ()];
}