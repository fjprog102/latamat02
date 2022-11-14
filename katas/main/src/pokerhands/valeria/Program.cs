using System.Collections;

namespace PokerHands.Valeria
{
    public class Program
    {
        public static void Main()
        {
            GamePlayRules rules = new GamePlayRules(new string[] {"9H", "9D", "7C", "5S", "7D"});
            string res = rules.ApplyTwoPairs();
            Console.WriteLine(res);
        }
    }
}
