using System.Collections;

namespace PokerHands.Valeria
{
    public class Program
    {
        public static void Main(String[] args)
        {
            List<int> Values = new List<int>();
            GamePlayRules Rules = new GamePlayRules(new string[] {"AH","AC","AS","AD","3S"});
            string res = Rules.ApplyFourOfAKindRule();
            Console.WriteLine(res);
        }
    }
}
