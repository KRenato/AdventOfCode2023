namespace AdventOfCode2023.Puzzles;

internal class Day1(string dataPath) : Puzzle(dataPath)
{
    public override async Task<string> GetPart1AnswerAsync()
    {
        var data = await GetDataAsync();
        return data[0] + " Part 1";
    }

    public override async Task<string> GetPart2AnswerAsync()
    {
        var data = await GetDataAsync();
        return data[0] + " Part 2";
    }
}
