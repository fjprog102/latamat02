namespace PokerHands.Valeria
{
    public partial class GamePlayRules
    {
        public string ApplyStraightFlushRule()
        {
            return Values.Distinct().Count() == 1 ? "StraighyFlush!" : "None";
        }

        public string ApplyFourOfAKindRule()
        {
            return ValuesCount.ContainsValue(4) ? "FourOfAKind" : "None";
        }
    }
}
