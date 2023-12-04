using Common;

namespace AdventOfCode2023.Puzzles.Day3;

internal class Day3Puzzle : Puzzle
{
    public override string Year => "2023";

    public override string Day => "3";

    public override async Task<string> GetPart1AnswerAsync()
    {
        var data = await GetDataAsync();

        int sum = 0;

        var map = CreateMap(data);

        Coordinate? currentOrigin = null;
        int yBoundary = map.GetYBoundary();
        int xBoundary = map.GetYBoundary();

        for (int y = 0; y <= yBoundary; y++)
        {
            for (int x = 0; x <= xBoundary; x++)
            {
                if (char.IsNumber(map[x, y].Value))
                {
                    currentOrigin ??= new Coordinate(x, y);
                }
                else
                {
                    sum += UpdateSum(map, ref currentOrigin, x - 1, y - 1);
                }
            }

            sum += UpdateSum(map, ref currentOrigin, xBoundary, y - 1);
        }

        return $"Total is {sum}";
    }

    public override async Task<string> GetPart2AnswerAsync()
    {
        var data = await GetDataAsync();

        var map = CreateMap(data);

        Coordinate? currentOrigin = null;
        var gearCells = new Dictionary<Coordinate, List<int>>();
        int yBoundary = map.GetYBoundary();
        int xBoundary = map.GetYBoundary();

        for (int y = 0; y <= yBoundary; y++)
        {
            for (int x = 0; x <= xBoundary; x++)
            {
                currentOrigin = char.IsNumber(map[x, y].Value)
                    ? currentOrigin ?? new Coordinate(x, y)
                    : UpdateCells(map, currentOrigin, gearCells, x - 1, y - 1);
            }

            currentOrigin = UpdateCells(map, currentOrigin, gearCells, xBoundary, y);
        }

        int sum = gearCells.Where(c => c.Value.Count > 1)
            .Select(c => c.Value.Aggregate((p, n) => p * n))
            .Sum();

        return $"Total is {sum}";
    }

    private static CoordinateMap<Cell> CreateMap(string[] data)
    {
        var map = new CoordinateMap<Cell>();

        for (int y = 0; y < data.Length; y++)
        {
            var currentCell = data[y];
            for (int x = 0; x < currentCell.Length; x++)
            {
                map.Add(new Cell(x, y, currentCell[x]));
            }
        }

        return map;
    }

    private static int UpdateSum(CoordinateMap<Cell> map, ref Coordinate? currentOrigin, int x, int y)
    {
        int increment = 0;
        if (currentOrigin.HasValue)
        {
            if (DoesBorderHaveSpecial(map, currentOrigin.Value, new Coordinate(x, y)))
            {
                increment = GetNumber(map, currentOrigin.Value, new Coordinate(x, y));
            }
            currentOrigin = null;
        }

        return increment;
    }

    private static Coordinate? UpdateCells(CoordinateMap<Cell> map, Coordinate? currentOrigin, Dictionary<Coordinate, List<int>> gearCells, int x, int y)
    {
        if (currentOrigin.HasValue)
        {
            var gearCell = DoesBorderHaveGear(map, currentOrigin.Value, new Coordinate(x, y - 1));
            if (gearCell.HasValue)
            {
                var value = GetNumber(map, currentOrigin.Value, new Coordinate(x, y - 1));
                if (gearCells.TryGetValue(gearCell.Value, out List<int>? gearCellList))
                {
                    gearCellList.Add(value);
                }
                else
                {
                    gearCells.Add(gearCell.Value, [value]);
                }
            }
            currentOrigin = null;
        }

        return currentOrigin;
    }

    private static bool DoesBorderHaveSpecial(CoordinateMap<Cell> map, Coordinate origin, Coordinate termination)
    {
        for (int y = origin.Y - 1; y <= origin.Y + 1; y++)
        {
            for (int x = origin.X - 1; x <= termination.X + 1; x++)
            {
                var coord = new Coordinate(x, y);
                if (map.Contains(coord) && !char.IsNumber(map[coord].Value) && map[coord].Value != '.')
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static Coordinate? DoesBorderHaveGear(CoordinateMap<Cell> map, Coordinate origin, Coordinate termination)
    {
        for (int y = origin.Y - 1; y <= origin.Y + 1; y++)
        {
            for (int x = origin.X - 1; x <= termination.X + 1; x++)
            {
                var coord = new Coordinate(x, y);
                if (map.Contains(coord) && map[coord].Value == '*')
                {
                    return coord;
                }
            }
        }

        return null;
    }

    private static int GetNumber(CoordinateMap<Cell> map, Coordinate origin, Coordinate termination)
    {
        string value = string.Empty;

        for (int i = origin.X; i <= termination.X; i++)
        {
            value += map[i, origin.Y].Value;
        }

        return int.Parse(value);
    }
}
