using Common;

namespace AdventOfCode2023.Puzzles.Day3;

internal class Cell(int x, int y, char value) : IMappedObject
{
    public Coordinate Coordinate { get; } = new Coordinate(x, y);

    public char Value { get; } = value;
}
