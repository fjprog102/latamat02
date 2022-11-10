using System;
using System.Text.RegularExpressions;

namespace SquareDigit.Valeria
{
    public class SquareDigitCalculator
    {
        public string GetTheSquareDigit(string s)
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
}
