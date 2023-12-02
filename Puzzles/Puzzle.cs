namespace AdventOfCode2023.Puzzles;

internal abstract class Puzzle : IPuzzle
{
    private readonly Lazy<Task<string[]>> _data;

    public Puzzle()
    {
        _data = new(() => GetDataTask(DataPath));
    }

    public abstract string Year { get; }

    public abstract string Day { get; }

    private string DataPath => $"Data\\{Year}-{Day}-Data.txt";

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
    string Year { get; }

    string Day { get; }

    Task<string> GetPart1AnswerAsync();

    Task<string> GetPart2AnswerAsync();
}
