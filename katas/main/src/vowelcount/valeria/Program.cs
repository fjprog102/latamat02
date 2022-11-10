using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace VowelCount.Valeria
{
    public class VowelCounter
    {
        public string CountVowels(string str)
        {
            string res = "The message must be in lower case";
            Regex regex = new Regex(@"^[a-z0-9\s]+$");
            if (regex.IsMatch(str))
            {
                res = Regex.Matches(str, "a|e|i|o|u").Count.ToString();
            }

            return res;
        }

        public static void main(string args) { }
    }
}
