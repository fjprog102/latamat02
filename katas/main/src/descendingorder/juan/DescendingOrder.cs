namespace DescentingOrder.Juan
{
    public class DescentingOrderJuan
    {
        public static string char_list_to_string(char[] arr)
        {
            return new string(arr);
        }

        public static string descenting_order(string user_input)
        {
            char[] values = user_input.ToArray();
            Array.Sort(values, new ReverseString());

            return char_list_to_string(values);
        }
    }

    public class ReverseString : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            return y.CompareTo(x);
        }
    }
}
