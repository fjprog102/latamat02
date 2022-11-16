namespace PokerHands.Joaquin;

using System.Linq;

public class HandRanking
{
    public HandEvaluator Evaluator = new HandEvaluator();
    public int ranking = 0;
    public string type = "high card";
    public int[] orderedHand = new int[5];
    private readonly Dictionary<string, int> pokerRanking = new Dictionary<string, int>
    {
        {"high card", 0},
        {"pair", 1},
        {"two pairs", 2},
        {"three of a kind", 3},
        {"straight", 4},
        {"flush", 5},
        {"full house", 6},
        {"four of a kind", 7},
        {"straight flush", 8},
    };

    public int GetHandRanking(Hand hand)
    {
        ranking = Evaluator.Evaluate(hand);
        GetRankingType(ranking);
        return ranking;

    }

    public string GetRankingType(int ranking)
    {
        type = pokerRanking.FirstOrDefault(x => x.Value == ranking).Key;
        return type;
    }

    public List<Card> OrderHandByCardWeight(Hand hand)
    {
        return hand.Cards.OrderByDescending(card => card.weight).ToList();
    }

    public bool CheckOrder(List<Card> cards)
    {
        bool isOrdered = true;
        for (int i = 0; i < cards.Count() - 1; i++)
        {
            if (cards[i].weight < cards[i + 1].weight)
            {
                return _ = false;
            }
        }

        return isOrdered;
    }
}
