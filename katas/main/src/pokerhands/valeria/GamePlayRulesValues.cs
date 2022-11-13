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
            IEnumerable<int> duplicates = Values
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(x => x.Key);

            Console.WriteLine("Duplicate elements are: " + String.Join(",", duplicates));
            return "FourOfAKind";
        }
    }
}
