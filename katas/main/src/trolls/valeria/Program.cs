using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Trolls.Valeria
{
    public class Troll
    {
        public string EatVowels(string mssg)
        {
            var vowels = new HashSet<char>("aeiouAEIOU");
            mssg = new string(mssg.Where(c => !vowels.Contains(c)).ToArray());
            return mssg;
        }
    }
}
