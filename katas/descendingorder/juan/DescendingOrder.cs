namespace DescentingOrder.Juan
{
    public class DescentingOrderJuan
    {
        static public String char_list_to_string(char[] arr)
        {
            return new String(arr);
        }

        static public String descenting_order(String user_input)
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
