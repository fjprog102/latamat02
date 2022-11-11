namespace HighestLowest.Juan
{
    public class HighestLowestJuan
    {
        public static string HighestLowest(string user_input)
        {
            var values = StringToIntList(user_input, " ");
            return (string.Format("{0} {1}", values.Max(), values.Min()));
        }

        public static int[] StringToIntList(string str, string separator)
        {
            return Array.ConvertAll(str.Split(separator), value => int.Parse(value));
        }
    }
}
