using AdventOfCode2023;

var puzzles = PuzzleBuilder.Build();

Console.WriteLine("Press ESC at any time to quit.");

while(true)
{
    Console.WriteLine("\n\nPlease select a puzzle:\n");

    foreach (var puzzle in puzzles.OrderBy(p => p.Year).ThenBy(p => p.Day))
    {
        Console.WriteLine($"{puzzle.Day}.) Day {puzzle.Day}");
    }

    Console.WriteLine();

    var input = Console.ReadKey();

    if (input.Key == ConsoleKey.Escape)
    {
        break;
    }

    if (!puzzles.Any(p => p.Day == input.KeyChar.ToString()))
    {
        Console.WriteLine("\n\nInvalid selection, please select a valid puzzle.");
        continue;
    }

    var selectedPuzzle = puzzles.Single(p => p.Day == input.KeyChar.ToString());

    var part1Answer = await selectedPuzzle.GetPart1AnswerAsync();
    Console.WriteLine($"\n\nPart 1 result:\n\n{part1Answer}\n");

    var part2Answer = await selectedPuzzle.GetPart2AnswerAsync();
    Console.WriteLine($"Part 2 result:\n\n{part2Answer}\n");

    Console.WriteLine("Press any key to continue.");

    Console.ReadKey();

    if (input.Key == ConsoleKey.Escape)
    {
        break;
    }
}