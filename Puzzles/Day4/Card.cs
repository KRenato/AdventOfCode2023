namespace AdventOfCode2023.Puzzles.Day4;

internal class Card(int id, IEnumerable<int> values, IEnumerable<int> winners)
{
    public int CardId => id;

    public IEnumerable<int> Values = values;

    public IEnumerable<int> Winners = winners;

    public int NumberOfWinners => Values
        .Where(Winners.Contains)
        .Count();

    public int GetScore()
    {
        if (NumberOfWinners > 0)
        {
            return (int)Math.Pow(2, NumberOfWinners - 1);
        }

        return 0;
    }
}
