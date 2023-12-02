namespace AdventOfCode2023.Puzzles;

internal class Day1(string dataPath) : Puzzle(dataPath)
{
    private readonly Dictionary<string, string> _digits = new()
    {
        { "0", "zero" },
        { "1", "one" },
        { "2", "two" },
        { "3", "three" },
        { "4", "four" },
        { "5", "five" },
        { "6", "six" },
        { "7", "seven" },
        { "8", "eight" },
        { "9", "nine" }
    };

    public override async Task<string> GetPart1AnswerAsync()
    {
        var data = await GetDataAsync();

        int total = 0;

        foreach (var value in data)
        {
            var firstDigit = value.First(char.IsDigit);
            var lastDigit = value.Last(char.IsDigit);

            var number = int.Parse(firstDigit.ToString() + lastDigit.ToString());

            total += number;
        }

        return $"Calibration value: {total}";
    }

    public override async Task<string> GetPart2AnswerAsync()
    {
        var data = await GetDataAsync();

        int total = 0;

        foreach (var value in data)
        {
            var firstDigit = FindFirstDigit(value) ?? throw new InvalidOperationException("No digit found.");
            var lastDigit = FindLastDigit(value) ?? throw new InvalidOperationException("No digit found.");

            var number = int.Parse(firstDigit + lastDigit);

            total += number;
        }

        return $"Calibration value: {total}";
    }

    private string? FindFirstDigit(string value)
    {
        for (int i = 0; i < value.Length; i++)
        {
            var digit = GetDigitAtIndex(value, i);
            if (digit is not null)
                return digit;
        }

        return null;
    }

    private string? FindLastDigit(string value)
    {
        for (int i = value.Length - 1; i >= 0; i--)
        {
            var digit = GetDigitAtIndex(value, i);
            if (digit is not null)
                return digit;
        }

        return null;
    }

    private string? GetDigitAtIndex(string value, int idx)
    {
        foreach (var digit in _digits)
        {
            if (value[idx].ToString() == digit.Key ||
                (value.Length - idx >= digit.Value.Length && value[idx..(idx + digit.Value.Length)] == digit.Value))
            {
                return digit.Key;
            }
        }

        return null;
    }
}
