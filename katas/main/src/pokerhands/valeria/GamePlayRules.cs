using System.Text.RegularExpressions;

namespace PokerHands.Valeria
{
    public partial class GamePlayRules
    {
        List<int> Values = new List<int>();
        List<char> Suits = new List<char>();
        public List<int> GetValues(string []Hand)
        {
            foreach (var Item in Hand)
            {   
                string NItem = Regex.Replace(Item[0].ToString(),@"J|Q|K","10");
                NItem = Regex.Replace(NItem,@"A","11");
                Values.Add(int.Parse(NItem.ToString()));
            }
            return Values;
        }
        public  List<char> GetSuits(string []Hand)
        {
            Suits = Hand.Select(s => s[1]).ToList();
            return Suits;
        }
    }
}
