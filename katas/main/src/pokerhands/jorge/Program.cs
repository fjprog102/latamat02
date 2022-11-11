namespace PokerGame.Jorge;

public class PokerGameCompetitors
{
    public string BothHands(string CompetitorsHand)
    {
        double blackHand = new PokerHand().HandToPlay(CompetitorsHand.Substring(7, 14));
        double whiteHand = new PokerHand().HandToPlay(CompetitorsHand.Substring(30, 14));

        //List<string> ListPokerHandBlack = blackHand.Split().ToList();
        //List<string> ListPokerHandWhite = whiteHand.Split().ToList();

        return blackHand > whiteHand
            ? "Black wins - with " + results[blackHand]
            : "White wins - with " + results[whiteHand];
    }

    public Dictionary<double, string> results = new Dictionary<double, string>
    {
        { 0, "ERROR!" },
        { 1, "Highcard" },
        { 2, "Pair" },
        { 2.1, "Two Pairs" },
        { 3, "Three of a kind" },
        { 3.1, "Straight" },
        { 3.2, "Flush" },
        { 3.3, "Full House" },
        { 4, "Four of a kind" },
        { 5, "Straight Flush" }
    };
}

public class PokerHand
{
    public double HandToPlay(string ListPokerHand)
    {
        List<string> CurrentPokerHand = ListPokerHand.Split().ToList();
        //Get number of repeated values
        var handNums =
            from card in CurrentPokerHand
            group card by card[0] into newGroup
            let count = newGroup.Count()
            orderby count descending
            select new { Value = newGroup.Key, Count = count };

        //Get number of repeated suits
        var handSuits =
            from card in CurrentPokerHand
            group card by card[1] into newGroup
            let count = newGroup.Count()
            orderby count descending
            select new { Value = newGroup.Key, Count = count };

        bool AllSameSuit = false; // Show if all cards are same suit.
        double HandScore = 0; // Score in hand. ej. Pair, Full...
        string HandScoreValue = ""; // Value of the score in hand. ej. A, 7...
        string HighestCard = "0"; // Highest value of cards. ej. A
        string LowestCard = "A"; // Lowest value of cards. ej. A
        int pairCount = 0; // Counter if hand has pairs.

        List<string> PairArray = new List<string>();
        foreach (var suit in handSuits)
        {
            AllSameSuit = (suit.Count == 5);
        }
        foreach (var num in handNums)
        {
            if (num.Count > HandScore)
            {
                HandScore = num.Count;
                HandScoreValue = num.Value.ToString();
            }
            if (num.Count == 2)
            {
                PairArray.Add(num.Value.ToString());
            }

            HighestCard =
                ValueOfCards[num.Value.ToString()] > ValueOfCards[HighestCard]
                    ? num.Value.ToString()
                    : HighestCard;
            LowestCard =
                ValueOfCards[num.Value.ToString()] < ValueOfCards[LowestCard]
                    ? num.Value.ToString()
                    : LowestCard;
            pairCount = num.Count == 2 ? ++pairCount : pairCount;
        }

        // Conditionals to get score
        double Score()
        {
            if (HandScore == 1)
            {
                HandScoreValue = HighestCard;
                if (AllSameSuit)
                {
                    HandScore = 3.2;
                }
                if (ValueOfCards[HighestCard] - ValueOfCards[LowestCard] == 4)
                {
                    HandScore = 3.1;
                    if (AllSameSuit)
                    {
                        HandScore = 5;
                    }
                }
            }
            if (pairCount == 2)
            {
                HandScore = 2.1;
                HandScoreValue = String.Join(" & ", PairArray.ToArray());
            }
            if (HandScore == 3 && pairCount == 1)
            {
                HandScore = 3.3;
            }
            return HandScore;
        }
        return Score();
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
