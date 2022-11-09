using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Trolls.Valeria
{
    public class Troll
    {
        public string EatVowels(string Mssg)
        {
            var Vowels = new HashSet<char>("aeiouAEIOU");
            Mssg = new string(Mssg.Where(c => !Vowels.Contains(c)).ToArray());
            return Mssg;
        }
    }
}
