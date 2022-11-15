namespace PokerHands.Valeria
{
    public partial class GamePlayRules
    {
        public string[] Hand = { };
        public List<string> Values = new List<string>();
        public List<char> Suits = new List<char>();
        public Dictionary<string, int> ValuesCount = new Dictionary<string, int>();
        public Dictionary<char, int> SuitsCount = new Dictionary<char, int>();
        public GamePlayRules(string[] hand)
        {
            Hand = hand;
            GetValues();
            GetSuits();
            GetGridValuesCounter();
            GetGridSuitsCounter();
        }
        public void GetValues()
        {
            foreach (var item in Hand)
            {
                string Value = item.Length > 2? Value = "10" : Value =item[0].ToString();
                Values.Add(Value);   
            }
            Values.Sort(StringComparer.OrdinalIgnoreCase);
        }
        public void GetSuits()
        {
            Suits = Hand.Select(s => s[s.Length-1]).ToList();
        }
        public void GetGridValuesCounter()
        {
            var q = from x in Values group x by x into g let count = g.Count() orderby count descending select new { Value = g.Key, Count = count };
            foreach (var x in q)
            {
                ValuesCount.Add(x.Value, x.Count);
            }
        }
        public void GetGridSuitsCounter()
        {
            var q = from x in Suits group x by x into g let count = g.Count() orderby count descending select new { Value = g.Key, Count = count };
            foreach (var x in q)
            {
                SuitsCount.Add(x.Value, x.Count);
            }
        }
    }
}
