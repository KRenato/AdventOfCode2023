namespace AdventOfCode2023.Puzzles.Day4;

internal class Day4Puzzle : Puzzle
{
    public override string Year => "2023";

    public override string Day => "4";

    public override async Task<string> GetPart1AnswerAsync()
    {
        var data = await GetDataAsync();

        var score = data.Select(v => CardBuilder.Build(v).GetScore()).Sum();

        return $"Score: {score}";
    }

    public override async Task<string> GetPart2AnswerAsync()
    {
        var data = await GetDataAsync();

        var cards = data.Select(CardBuilder.Build);
        var cardCounts = new Dictionary<int, int>();

        foreach (var card in cards)
        {
            IncrementCardCount(cardCounts, card.CardId, 1);

            for (int i = card.CardId + 1; i <= card.NumberOfWinners + card.CardId; i++)
            {
                IncrementCardCount(cardCounts, i, cardCounts[card.CardId]);
            }
        }

        return $"Total cards: {cardCounts.Values.Sum()}";
    }

    private static void IncrementCardCount(Dictionary<int, int> counts, int id, int amount)
    {
        if (counts.ContainsKey(id))
            counts[id] += amount;
        else
            counts[id] = amount;
    }
}
