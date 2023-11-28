using AdventOfCode2023;

var puzzles = PuzzleBuilder.Build();

Console.WriteLine("Press ESC at any time to quit.");

while(true)
{
    Console.WriteLine("\n\nPlease select a puzzle:\n");

    foreach (var puzzleKvp in puzzles)
    {
        Console.WriteLine($"{puzzleKvp.Key}.) Day {puzzleKvp.Key}");
    }

    Console.WriteLine();

    var input = Console.ReadKey();

    if (input.Key == ConsoleKey.Escape)
    {
        break;
    }

    if (!int.TryParse(input.KeyChar.ToString(), out int keyValue) || !puzzles.ContainsKey(keyValue))
    {
        Console.WriteLine("\n\nInvalid selection, please select a valid puzzle.");
        continue;
    }

    var selectedPuzzle = puzzles[keyValue];

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