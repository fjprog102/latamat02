using System.Text.RegularExpressions;

namespace PokerHands.Valeria
{
    
    public class Dealer
    {

    }
    public class Player
    {
        List<int> Values = new List<int>();
        List<char> Suit = new List<char>();
        
        public void OrderValues(string []Hand)
        {
            foreach (var Item in Hand)
            {   
                string NItem = Regex.Replace(Item[0].ToString(),@"J|Q|K","10");
                NItem = Regex.Replace(NItem,@"A","20");
                Values.Add(int.Parse(NItem.ToString()));
            }
        }

        public void OrderSuits(string []Hand)
        {
            Suit = Hand.Select(s => s[1]).ToList();
        }

        public void ApplyStraightFlushRules()
        {
            if(Values.Distinct().Count() == 1)
            {
                Console.WriteLine("WIN!!!");
            }
        }
    }
}