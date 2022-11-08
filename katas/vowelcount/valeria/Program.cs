﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace VowelCount.Valeria
{
    public class VowelCounter
    {
        public static string CountVowels(string str)
        {
            string res = "The message must be in lower case";
            Regex regex = new Regex(@"^[a-z0-9\s]+$");
            if (regex.IsMatch(str))
            {
                var Vowels = new HashSet<char>("aeiou");
                res = Regex.Matches(str, "a|e|i|o|u").Count.ToString();
            }
            return res;
        }
    }
}
