using AdventOfCode2023.Puzzles;
using System.Reflection;

namespace AdventOfCode2023;

internal static class PuzzleBuilder
{
    public static Dictionary<int, IPuzzle> Build()
    {
        var allTypes = Assembly.GetExecutingAssembly().GetTypes();

        var puzzleTypes = allTypes.Where(type =>
            type.IsClass && !type.IsAbstract && typeof(IPuzzle).IsAssignableFrom(type)
        );

        var puzzles = new Dictionary<int, IPuzzle>();

        foreach (var puzzleType in puzzleTypes)
        {
            var puzzleNumber = int.Parse(puzzleType.Name[^1].ToString());
            var puzzle = Activator.CreateInstance(puzzleType, $"Data\\{puzzleType.Name}Data.txt") as IPuzzle
                ?? throw new InvalidOperationException("Unable to instantiate puzzle.");

            puzzles.Add(puzzleNumber, puzzle);
        }

        return puzzles;
    }
}
