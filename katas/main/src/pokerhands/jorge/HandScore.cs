namespace PokerGame.Hands.Jorge;
using System.Linq;

public class PokerHand
{
    public List<string> PairArray = new List<string>(); // List to know pairs.

    public double HandToPlay(string listPokerHand)
    {
        List<string> currentPokerHand = listPokerHand.Split().ToList();

        //Know if all suits are the same
        bool AllSameSuit =
            (
                from card in currentPokerHand
                group card by card[1] into newGroup
                let count = newGroup.Count()
                orderby count descending
                select new { Value = newGroup.Key, Count = count }
            )
                .ToList()
                .Count() == 1;

        //Get number of repeated values
        var handNums = (
            from card in currentPokerHand
            group card by card[0] into newGroup
            let count = newGroup.Count()
            orderby count descending
            select new { Value = newGroup.Key, Count = count }
        ).ToList();

        var HandScore = handNums.Max(card => card.Count);
        var HandScoreValue = handNums[0].Value.ToString();
        var HighestCard = ValueOfCards
            .FirstOrDefault(
                x => x.Value == handNums.Max(card => ValueOfCards[card.Value.ToString()])
            )
            .Key;
        var LowestCard = ValueOfCards
            .FirstOrDefault(
                x => x.Value == handNums.Min(card => ValueOfCards[card.Value.ToString()])
            )
            .Key;

        var PairCount = handNums.Count(x => x.Count == 2);

        foreach (var num in handNums)
        {
            if (num.Count == 2)
            {
                PairArray.Add(num.Value.ToString());
            }
        }

        return Score(HandScore, HandScoreValue, HighestCard, LowestCard, AllSameSuit, PairCount);
    }

    public double Score(
        double HandScore,
        string HandScoreValue,
        string HighestCard,
        string LowestCard,
        bool AllSameSuit,
        int PairCount
    )
    {
        // Conditionals to get score
        if (HandScore == 1) // if highcard
        {
            if (AllSameSuit) // if all same suit
            {
                HandScore = 3.2;
            }

            if (ValueOfCards[HighestCard] - ValueOfCards[LowestCard] == 4) // if consecutive
            {
                HandScore = 3.1;
                if (AllSameSuit) // if all same suit
                {
                    HandScore = 5;
                }
            }
        }

        if (PairCount == 2) // if two pairs
        {
            HandScore = 2.1;
            _ = string.Join(" & ", PairArray.ToArray());
        }

        if (HandScore == 3 && PairCount == 1) // if full house
        {
            HandScore = 3.3;
        }

        return HandScore;
    }

    //Dictionary to give values to cards
    public Dictionary<string, int> ValueOfCards = new Dictionary<string, int>
    {
        { "A", 14 },
        { "0", 0 },
        { "2", 2 },
        { "3", 3 },
        { "4", 4 },
        { "5", 5 },
        { "6", 6 },
        { "7", 7 },
        { "8", 8 },
        { "9", 9 },
        { "T", 10 },
        { "J", 11 },
        { "Q", 12 },
        { "K", 13 },
    };
}
