using System;

namespace HighestLowestKata.Valeria
{
    public class HighestLowest
    {
        public string GetHighAndLow(string s)
        {
            var array = Array.ConvertAll(s.Split(' '), int.Parse);
            return array.Max() + " " + array.Min();
        }
    }
}
