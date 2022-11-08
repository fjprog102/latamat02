using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyConsoleApp
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
    public class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine(Troll.EatVowels("This website is for losers LOL!"));
        }
    }
}
