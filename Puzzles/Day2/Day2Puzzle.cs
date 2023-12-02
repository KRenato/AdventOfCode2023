namespace AdventOfCode2023.Puzzles.Day2;

internal class Day2Puzzle : Puzzle
{
    public override string Year => "2023";

    public override string Day => "2";

    public override async Task<string> GetPart1AnswerAsync()
    {
        var data = await GetDataAsync();

        return $"Calibration value: 1";
    }

    public override async Task<string> GetPart2AnswerAsync()
    {
        var data = await GetDataAsync();

        return $"Calibration value: 2";
    }
}
