using System.Collections;

namespace PokerHands.Valeria
{
    public class Program
    {
        public static void Main()
        {
            GamePlayRules rules = new GamePlayRules(new string[] {"AH","AC","AS","AD","3S"});
            string res = rules.ApplyFourOfAKindRule();
            Console.WriteLine(res);
        }
    }
}
