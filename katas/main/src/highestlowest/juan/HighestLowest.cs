namespace HighestLowest.Juan
{
    public class HighestLowestJuan
    {
        public static string highest_lowest(string user_input)
        {
            var values = string_to_int_list(user_input, " ");
            return (string.Format("{0} {1}", values.Max(), values.Min()));
        }

        public static int[] string_to_int_list(string str, string separator)
        {
            return Array.ConvertAll(str.Split(separator), value => int.Parse(value));
        }
    }
}
