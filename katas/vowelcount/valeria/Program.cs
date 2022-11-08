using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyConsoleApp
{
    public class Class1
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
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(Class1.CountVowels("abc def ghi"));
            Console.WriteLine(Class1.CountVowels("aBc DeF ghi"));
            Console.WriteLine(Class1.CountVowels("abc 123 ghi"));
            Console.WriteLine(Class1.CountVowels("abC 123 ghi"));
        }
    }
}
