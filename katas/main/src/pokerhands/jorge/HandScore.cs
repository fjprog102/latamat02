namespace PokerGame.Hands.Jorge;
using System.Linq;

public class PokerHand
{
    public List<int> pairArray = new List<int>(); // List to know pairs.
    public string[] resultValues = new string[4]; // Array for results

    public string[] HandToPlay(string listPokerHand)
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
        var handScoreValue = handNums[0].Value.ToString();
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
                pairArray.Add(int.Parse(num.Value.ToString()));
            }
        }

        return Score(handScore, highestCard, lowestCard, allSameSuit, pairCount, handScoreValue);
    }

    public string[] Score(
        double handScore,
        string highestCard,
        string lowestCard,
        bool allSameSuit,
        int pairCount,
        string handScoreValue
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

        var newPairArray = pairArray.ToArray();
        Array.Sort(newPairArray);

        if (pairCount == 2) // if two pairs
        {
            handScore = 2.1;
            handScoreValue = newPairArray[1].ToString();
        }

        if (handScore == 3 && pairCount == 1) // if full house
        {
            handScore = 3.3;
        }

        resultValues[0] = handScore.ToString();
        resultValues[1] = handScoreValue;
        resultValues[2] = newPairArray.Length > 0 ? newPairArray[0].ToString() : "0";
        resultValues[3] = highestCard;

        //Console.WriteLine("handScore: " + resultValues[0]);
        //Console.WriteLine("handScoreValue: " + resultValues[1]);
        //Console.WriteLine("Tiebreaker Pair: " + resultValues[2]);
        //Console.WriteLine("highestCard " + resultValues[3]);
        //Console.WriteLine("");

        return resultValues;
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
