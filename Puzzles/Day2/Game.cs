namespace AdventOfCode2023.Puzzles.Day2;

internal class Game(int gameId, IEnumerable<Pull> pulls)
{
    public int GameId => gameId;

    public int MaxRed => Pulls.Select(p => p.RedCount).Max();

    public int MaxGreen => Pulls.Select(p => p.GreenCount).Max();

    public int MaxBlue => Pulls.Select(p => p.BlueCount).Max();

    public IEnumerable<Pull> Pulls = pulls;
}
