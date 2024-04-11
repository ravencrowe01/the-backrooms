using Godot;
using Backrooms.Common;

namespace Backrooms.Common;

public static class Vector2Extensions {
    public static int IntX (this Vector2 vec) => (int) vec.X;

    public static int IntY (this Vector2 vec) => (int) vec.Y;

    public static Direction GetDirectionRelativeTo (this Vector2 position, Vector2 relative) {
        Direction dir;

        var dif = position - relative;

        return dir;
    }
}