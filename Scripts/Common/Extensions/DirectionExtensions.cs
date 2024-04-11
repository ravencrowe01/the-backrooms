namespace Backrooms.Common;

public static class DirectionExtension {
    public static Direction Opposite (this Direction direction) => direction switch {
        Direction.North => Direction.South,
        Direction.South => Direction.North,
        Direction.East => Direction.West,
        Direction.West => Direction.East,
        Direction.NorthEast => Direction.NorthWest,
        Direction.NorthWest => Direction.NorthEast,
        Direction.SouthEast => Direction.SouthWest,
        Direction.SouthWest => Direction.SouthEast,
        _ => throw new System.NotImplementedException ($"Direction {direction} does not exist."),
    };

    public static Direction ToVector2 (this Direction direction) => direction switch {
      Direction.North => new Vector2 (1, 0),
      Direction.South => new Vector2 (-1, 0),
      Direction.East => new Vector2 (0, 1),
      Direction.West => new Vector2 (0, -1),
      Direction.NorthEast => new Vector2 (1, 1),
      Direction.NorthWest => new Vector2 (1, -1),
      Direction.SouthEast => new Vector2 (-1, 1),
      Direction.SouthWest => new Vector2 (-1, -1),
      _ => throw new System.NotImplementedException ($"Direction {direction} does not exist."),
    };
}
