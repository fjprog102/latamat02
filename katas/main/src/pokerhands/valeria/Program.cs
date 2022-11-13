using System.Collections;

namespace PokerHands.Valeria
{
    public class Program
    {
        public static void Main()
        {
            GamePlayRules Rules = new GamePlayRules(new string[] {"AH","AC","AS","AD","3S"});
            string res = Rules.ApplyFourOfAKindRule();
            Console.WriteLine(res);
        }
    }
}
