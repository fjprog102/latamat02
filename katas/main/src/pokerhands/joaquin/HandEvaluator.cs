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

        // int[] values = new int[5];

        // for (int i = 0; i < values.Length; i++)
        // {
        //     foreach (Card card in hand.Cards)
        //     {
        //         values[i] = card.weight;
        //     }
        // }

        // Array.Sort(values);

        // for (int i = 0; i < values.Length - 1; i++)
        // {
        //     if (values[i] + 1 != values[i + 1])
        //     {
        //         return false;
        //     }
        // }

        return true;
    }
}