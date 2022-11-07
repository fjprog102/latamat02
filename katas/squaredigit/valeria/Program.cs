using System;
using System.Text.RegularExpressions;

namespace MyConsoleApp
{
    public class Class1
    {
        public static string SquareDigit(string s)
        {
            string res = "a valid number is required";
            Regex regex = new Regex(@"^\d+$");
            if(regex.IsMatch(s)){
                res = "";
                foreach (char item in s)
                {
                    int sqr = (int)Char.GetNumericValue(item);
                    sqr = sqr * sqr;
                    res += sqr.ToString();
                }
            }
            return res;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Class1.SquareDigit(Console.ReadLine()));
        }
    }
}
