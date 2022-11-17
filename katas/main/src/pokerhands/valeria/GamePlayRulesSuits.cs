using System;
using System.Collections.Generic;
namespace PokerHands.Valeria
{
    public partial class GamePlayRules
    {
        public List<List<string>> ConsecutiveValues = new List<List<string>>() { new List<string> { "2", "3", "4", "5", "A" }, new List<string> { "2", "3", "4", "5", "6" }, new List<string> { "3", "4", "5", "6", "7" }, new List<string> { "4", "5", "6", "7", "8" }, new List<string> { "5", "6", "7", "8", "9" }, new List<string> { "6", "7", "8", "9", "10" }, new List<string> { "10", "7", "8", "9", "J" }, new List<string> { "10", "8", "9", "J", "Q" }, new List<string> { "10", "9", "J", "K", "Q" }, new List<string> { "10", "A", "J", "K", "Q" }, new List<string> { "2", "A", "J", "K", "Q" }, new List<string> { "2", "3", "A", "K", "Q" }, new List<string> { "2", "3", "4", "A", "K" } };
        public string ApplyStraightFlushRule()
        {
            var consecutiveHand = from ListValues in ConsecutiveValues where ListValues.SequenceEqual(Values) select ListValues.ToList();
            return SuitsCount.ContainsValue(5) && consecutiveHand.Count() > 0 ? "with straight flush: " + SuitsCount.ElementAt(0).Key : "None";
        }
        public string ApplyFlushRule()
        {
            return SuitsCount.ContainsValue(5) ? "with flush: " + SuitsCount.ElementAt(0).Key : "None";
        }
        public string ApplyStraightRule()
        {
            var consecutiveHand = from ListValues in ConsecutiveValues where ListValues.SequenceEqual(Values) select ListValues.ToList();
            return consecutiveHand.Count() > 0 ? "with straight" : "None";
        }
        public string ApplyHighCardRule()
        {
            return Values.Contains("A") ? "with high card: A" : Values.Contains("10") ? "with high card: 10" : "with high card: " + ValuesCount.ElementAt(4).Key;
        }
    }
}
