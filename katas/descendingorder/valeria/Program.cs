
using System;
using System.Linq;

namespace DescendingOrder
{
    public class DescendingOrder
    {
        public static string GetTheHighestValue(int MyNumber)
        {
            string res = "your input must be a non-negative integer";
            if(MyNumber > 0){
                res = String.Concat(MyNumber.ToString().OrderByDescending(c => c));
            }
            return res;
        }
    }
}
