
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyConsoleApp
{
    public class Class1
    {
        public static string DescendingOrder(int MyNumber)
        {
            string res = "your input must be a non-negative integer";
            if(MyNumber > 0){
                res = String.Concat(MyNumber.ToString().OrderByDescending(c => c));
            }
            return res;
        }
    }
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(Class1.DescendingOrder(42145));
            Console.WriteLine(Class1.DescendingOrder(145263));
            Console.WriteLine(Class1.DescendingOrder(123456789));
            Console.WriteLine(Class1.DescendingOrder(-123456789));
        }
    }
}
