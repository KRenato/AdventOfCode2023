namespace AdventOfCode2023.Puzzles.Day2;

internal static class GameBuilder
{
    public static Game Build(string dataRow)
    {
        var data = dataRow.Split(':', StringSplitOptions.TrimEntries);

        var id = int.Parse(data[0].Replace("Game ", ""));

        var pulls = data[1].Split(';', StringSplitOptions.TrimEntries);

        return new Game(id, pulls.Select(MapPull));
    }

    private static Pull MapPull(string input)
    {
        var sortedCubes = input.Split(",", StringSplitOptions.TrimEntries);

        int red = 0;
        int green = 0;
        int blue = 0;

        foreach (var color in sortedCubes)
        {
            if (color.Contains("red", StringComparison.CurrentCulture))
                red = int.Parse(color.Replace(" red", ""));
            else if (color.Contains("green", StringComparison.CurrentCulture))
                green = int.Parse(color.Replace(" green", ""));
            else if (color.Contains("blue", StringComparison.CurrentCulture))
                blue = int.Parse(color.Replace(" blue", ""));
        }

        return new Pull { RedCount = red, GreenCount = green, BlueCount = blue };
    }
}
