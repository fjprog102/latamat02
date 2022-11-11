namespace PokerHands.RankedHands.Adriel;

using Enums.Adriel;
using Hands.Adriel;
using HandsEvaluator.Adriel;

public class RankedHand
{
    public Hand Hand { get; }
    public Ranking Ranking { get; }

    public RankedHand(Hand hand)
    {
        var tempCards = hand.Cards.OrderBy(c => c.Value);
        string tempCardsString = string.Join(" ", tempCards);

        Hand = new Hand(tempCardsString);
        Ranking = new HandEvaluator().Evaluate(Hand);

        if ((Ranking == Ranking.Straight || Ranking == Ranking.StraightFlush) &&
        (hand.Contains(Value.Ace) && hand.Contains(Value.Two) && hand.Contains(Value.Three) &&
        hand.Contains(Value.Four) && hand.Contains(Value.Five)))
        {
            Hand.Cards.Insert(0, Hand.Cards[4]);
            Hand.Cards.RemoveAt(5);
        }
    }
}
