namespace AdventOfCode2023.Puzzles;

internal abstract class Puzzle(string dataPath) : IPuzzle
{
    private readonly Lazy<Task<string[]>> _data = new(() => GetDataTask(dataPath));

    public abstract Task<string> GetPart1AnswerAsync();

    public abstract Task<string> GetPart2AnswerAsync();

    protected async Task<string[]> GetDataAsync()
    {
        return await _data.Value.ConfigureAwait(false);
    }

    private static Task<string[]> GetDataTask(string path)
    {
        return File.ReadAllLinesAsync(path);
    }
}

internal interface IPuzzle
{
    public Task<string> GetPart1AnswerAsync();

    public Task<string> GetPart2AnswerAsync();
}
