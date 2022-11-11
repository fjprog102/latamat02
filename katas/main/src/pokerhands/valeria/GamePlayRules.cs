using System.Text.RegularExpressions;

namespace PokerHands.Valeria
{
    public class GamePlayRules
    {
        List<int> Values = new List<int>();
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
    }
}
