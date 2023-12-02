namespace AdventOfCode2023.Puzzles.Day2;

internal class Day2Puzzle : Puzzle
{
    public override string Year => "2023";

    public override string Day => "2";

    public override async Task<string> GetPart1AnswerAsync()
    {
        var data = await GetDataAsync();

        var games = data.Select(GameBuilder.Build);

        var sum = games
            .Where(g => g.MaxRed <= 12
                && g.MaxGreen <= 13
                && g.MaxBlue <= 14)
            .Sum(g => g.GameId);

        return $"Game ID total: {sum}";
    }

    public override async Task<string> GetPart2AnswerAsync()
    {
        var data = await GetDataAsync();

        var games = data.Select(GameBuilder.Build);

        var sum = games
            .Select(g => g.Pulls.Max(p => p.RedCount)
                * g.Pulls.Max(p => p.GreenCount)
                * g.Pulls.Max(p => p.BlueCount))
            .Sum();

        return $"Game ID total: {sum}";
    }
}
