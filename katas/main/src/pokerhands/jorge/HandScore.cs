namespace PokerGame.Hands.Jorge;
using System.Linq;

public class PokerHand
{
    public List<string> pairArray = new List<string>(); // List to know pairs.

    public double HandToPlay(string listPokerHand)
    {
        List<string> currentPokerHand = listPokerHand.Split().ToList();

        //Know if all suits are the same
        bool allSameSuit =
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

        var handScore = handNums.Max(card => card.Count);
        //var handScoreValue = handNums[0].Value.ToString();
        var highestCard = valueOfCards
            .FirstOrDefault(
                x => x.Value == handNums.Max(card => valueOfCards[card.Value.ToString()])
            )
            .Key;
        var lowestCard = valueOfCards
            .FirstOrDefault(
                x => x.Value == handNums.Min(card => valueOfCards[card.Value.ToString()])
            )
            .Key;

        var pairCount = handNums.Count(x => x.Count == 2);

        foreach (var num in handNums)
        {
            if (num.Count == 2)
            {
                pairArray.Add(num.Value.ToString());
            }
        }

        return Score(handScore, highestCard, lowestCard, allSameSuit, pairCount);
    }

    public double Score(
        double handScore,
        string highestCard,
        string lowestCard,
        bool allSameSuit,
        int pairCount
    )
    {
        // Conditionals to get score
        if (handScore == 1) // if highcard
        {
            handScoreValue = highestCard;
            if (allSameSuit) // if all same suit
            {
                handScore = 3.2;
            }

            if (valueOfCards[highestCard] - valueOfCards[lowestCard] == 4) // if consecutive
            {
                handScore = 3.1;
                if (allSameSuit) // if all same suit
                {
                    handScore = 5;
                }
            }
        }

        if (pairCount == 2) // if two pairs
        {
            handScore = 2.1;
            _ = string.Join(" & ", pairArray.ToArray());
        }

        if (handScore == 3 && pairCount == 1) // if full house
        {
            handScore = 3.3;
        }

        return handScore;
    }

    //Dictionary to give values to cards
    public Dictionary<string, int> valueOfCards = new Dictionary<string, int>
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
