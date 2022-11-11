using System;

namespace DescendingOrder.Joaquin
{
    public class DescendingClass
    {
        public int OrderDescent(int input)
        {
            char[] numbers = input.ToString().ToCharArray();
            string output = "";

            Array.Sort(numbers);
            Array.Reverse(numbers);

            foreach (char num in numbers)
            {
                output += num;
            }

            return int.Parse(output);
        }
    }
}
