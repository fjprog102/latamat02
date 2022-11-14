using System.Collections;
using System.Text.RegularExpressions;

namespace PokerHands.Valeria
{
    public partial class GamePlayRules
    {
        public String []Hand = {};
        public List<int> Values = new List<int>();
        public List<char> Suits = new List<char>();
        public Dictionary<int, int> ValuesCount = new Dictionary<int, int>();
        
        public GamePlayRules(string []hand)
        {
            Hand = hand;
            GetValues();
            GetSuits();
            GetGridValuesCounter();
        }
        public void GetValues()
        {
            foreach (var item in Hand)
            {   
                string nItem = Regex.Replace(item[0].ToString(),@"J|Q|K","10");
                nItem = Regex.Replace(nItem,@"A","11");
                Values.Add(int.Parse(nItem.ToString()));
            }
        }
        public void GetSuits()
        {
            Suits = Hand.Select(s => s[1]).ToList();
        }

        public void GetGridValuesCounter()
        {
            var q = from x in Values group x by x into g let count = g.Count() orderby count descending select new { Value = g.Key, Count = count };
            foreach (var x in q)
            {
                ValuesCount.Add(x.Value, x.Count);
            }
        }
    }
}
