namespace PokerHand.Joaquin;

public class HandEvaluator
{

    public bool IsStraightFlush(Hand hand)
    {
        return IsStraight(hand) && IsFlush(hand);
    }

    public bool IsPair(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.value).Where(v => v.Count() == 2).Count() == 1;
    }

    public bool IsTwoPairs(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.value).Where(v => v.Count() == 2).Count() == 2;
    }

    public bool IsThreeOfAKind(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.value).Where(v => v.Count() == 3).Any();
    }

    public bool IsFourOfAKind(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.value).Where(v => v.Count() == 4).Any();
    }

    public bool IsFullHouse(Hand hand)
    {
        return IsPair(hand) && IsThreeOfAKind(hand);
    }

    public bool IsFlush(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.suit).Count() == 1;
    }

    public bool IsStraight(Hand hand)
    {
        var orderedHand = hand.Cards.OrderByDescending(card => card.weight).ToArray();

        for(int i = 0; i < orderedHand.Length - 1; i++)
        {
            if(orderedHand[i].weight - 1 != orderedHand[i + 1].weight) return false;
        }

        return true;
    }
}