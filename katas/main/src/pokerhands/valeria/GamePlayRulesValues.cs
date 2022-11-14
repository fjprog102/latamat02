namespace PokerHands.Valeria
{
    public partial class GamePlayRules
    {
        public string ApplyStraightFlushRule()
        {
            return ValuesCount.ContainsValue(5) ? "with straight flush: " + ValuesCount.ElementAt(0).Key : "None";
        }
        public string ApplyFourOfAKindRule()
        {
            return ValuesCount.ContainsValue(4) ? "with four of a kind: " + ValuesCount.ElementAt(0).Key : "None";
        }
        public string ApplyFullHouseRule()
        {
            return ValuesCount.ContainsValue(3) && ValuesCount.ContainsValue(2) ? "with full house: " + ValuesCount.ElementAt(0).Key + " over " + ValuesCount.ElementAt(1).Key : "None";
        }
        public string ApplyThreeOfAKind()
        {
            return ValuesCount.ContainsValue(3) ? "with three of a kind: " + ValuesCount.ElementAt(0).Key : "None";
        }
        public string ApplyTwoPairs()
        {
            return ValuesCount.ContainsValue(2) && ValuesCount.ElementAt(1).Value == 2 ? "with two pairs: " + ValuesCount.ElementAt(0).Key + " and " + ValuesCount.ElementAt(1).Key : "None";
        }
    }
}
