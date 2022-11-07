using System;

namespace MyConsoleApp
{
    public class Class1
    {
        public static string highAndLow(string s)
        {
            var array = Array.ConvertAll(s.Split(' '), int.Parse);
            return array.Max() + " " + array.Min();
        }
    }
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(Class1.highAndLow("1 2 3 4 5"));
            Console.WriteLine(Class1.highAndLow("1 2 -3 4 5"));
            Console.WriteLine(Class1.highAndLow("1 9 3 4 -5"));
        }
    }
}
