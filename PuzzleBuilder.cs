using AdventOfCode2023.Puzzles;
using System.Reflection;

namespace AdventOfCode2023;

internal static class PuzzleBuilder
{
    public static List<IPuzzle> Build()
    {
        var allTypes = Assembly.GetExecutingAssembly().GetTypes();

        var puzzleTypes = allTypes.Where(type =>
            type.IsClass && !type.IsAbstract && typeof(IPuzzle).IsAssignableFrom(type)
        );

        var puzzles = new List<IPuzzle>();

        foreach (var puzzleType in puzzleTypes)
        {
            var puzzle = Activator.CreateInstance(puzzleType) as IPuzzle
                ?? throw new InvalidOperationException("Unable to instantiate puzzle.");

            puzzles.Add(puzzle);
        }

        return puzzles;
    }
}
