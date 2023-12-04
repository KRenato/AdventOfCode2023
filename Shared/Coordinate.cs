namespace Common;

public readonly struct Coordinate(int x, int y) : IEquatable<Coordinate>
{
    public int X { get; } = x;

    public int Y { get; } = y;

    public bool IsSameXAxisAs(Coordinate other)
    {
        return X == other.X;
    }

    public bool IsSameYAxisAs(Coordinate other)
    {
        return Y == other.Y;
    }

    public bool Equals(Coordinate other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Coordinate coordinate && Equals(coordinate);
    }

    public static bool operator == (Coordinate left, Coordinate right)
    {
        return left.Equals(right);
    }

    public static bool operator != (Coordinate left, Coordinate right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
