using System;

namespace HighestLowest
{
    public class HighestLowest
    {
        public static string GetHighAndLow(string s)
        {
            var array = Array.ConvertAll(s.Split(' '), int.Parse);
            return array.Max() + " " + array.Min();
        }
    }
}
