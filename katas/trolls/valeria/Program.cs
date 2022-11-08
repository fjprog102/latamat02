using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Troll
{
    public class Troll
    {
        public static string EatVowels(string Mssg)
        {
            var Vowels = new HashSet<char>("aeiouAEIOU");
            Mssg = new string(Mssg.Where(c => !Vowels.Contains(c)).ToArray());
            return Mssg;
        }
    }
}
