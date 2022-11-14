namespace PokerHand.Joaquin;

using System.Linq;

public class HandRanking : HandEvaluator
{

    public int ranking = 0;
    public string type = "high card";
    public int[] orderedHand = new int[5];
    Dictionary<string, int> pokerRanking = new Dictionary<string, int>
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
        // orderedCards = hand.Cards.GroupBy(card => (card.weight)).ToArray();
        if(IsStraightFlush(hand)) return ranking = 8;
        else if (IsFourOfAKind(hand)) return ranking = 7;
        else if (IsFullHouse(hand)) return ranking = 6; 
        else if (IsFlush(hand)) return ranking = 5;
        // else if (IsStraight(hand)) return ranking = 4;
        else if (IsThreeOfAKind(hand)) return ranking = 3;
        else if (IsTwoPairs(hand)) return ranking = 2;
        else if (IsPair(hand)) return ranking = 1;
        else return ranking = 0;
    }

    public string GetRankingType(int ranking)
    {
        this.type = pokerRanking.FirstOrDefault(x => x.Value == ranking).Key;
        return type;
    }

    public int[] OrderHandByCardValue(Hand hand)
    {
        Deck deck = new Deck();
        int index = 0;

        foreach (var card in hand.Cards)
        {
            orderedHand[index] = card.weight;
        }

        orderedHand.OrderByDescending(v => v);

        return orderedHand;
    }
}