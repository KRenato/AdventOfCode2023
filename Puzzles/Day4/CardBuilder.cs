namespace AdventOfCode2023.Puzzles.Day4;

internal static class CardBuilder
{
    public static Card Build(string dataRow)
    {
        var data = dataRow.Split(':', StringSplitOptions.TrimEntries);

        var id = int.Parse(data[0].Replace("Card ", ""));

        var numbers = data[1].Split('|', StringSplitOptions.TrimEntries);

        var values = numbers[0]
            .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        var winners = numbers[1]
            .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        return new Card(id, values, winners);
    }
}
