namespace PokerHands.Valeria
{
    public class Program
    {
        public static void Main(String[] args)
        {
            List<int> Values = new List<int>();
            GamePlayRules Rules = new GamePlayRules();
            Values = Rules.GetValues(new string[] {"AH","AC","AS","AD","3S"});
            String res = Rules.ApplyFourOfAKindRule();
            Console.WriteLine(res);
        }
    }
}
