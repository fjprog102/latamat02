namespace PokerHands.Valeria
{
    public partial class GamePlayRules
    {
        public String ApplyStraightFlushRule()
        {
            return Values.Distinct().Count() == 1 ? "StraighyFlush!" : "None";
        }

        public String ApplyFourOfAKindRule()
        {
            return ValuesCount.ContainsValue(4) ? "FourOfAKind" : "None";
        }
    }
}
