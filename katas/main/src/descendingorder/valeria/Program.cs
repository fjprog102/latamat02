
namespace DescendingOrder.Valeria;
using System;
using System.Linq;

public class DescendingOrderClass
{
    public string GetTheHighestValue(int MyNumber)
    {
        string res = "your input must be a non-negative integer";
        if (MyNumber > 0)
        {
            res = string.Concat(MyNumber.ToString().OrderByDescending(c => c));
        }

        return res;
    }
}

