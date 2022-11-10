namespace DescentingOrder.Juan
{
    public class DescentingOrderJuan
    {
        public static string CharListToString(char[] arr)
        {
            return new string(arr);
        }

        public static string DescentingOrder(string user_input)
        {
            char[] values = user_input.ToArray();
            Array.Sort(values, new ReverseString());

            return CharListToString(values);
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
