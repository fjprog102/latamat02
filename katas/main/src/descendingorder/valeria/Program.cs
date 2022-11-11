namespace DescendingOrder.Valeria;
using System;
using System.Linq;

public class DescendingOrderClass
{
    public string GetTheHighestValue(int myNumber)
    {
        string res = "your input must be a non-negative integer";
        if (myNumber > 0)
        {
            res = string.Concat(myNumber.ToString().OrderByDescending(c => c));
        }

        return res;
    }
}
