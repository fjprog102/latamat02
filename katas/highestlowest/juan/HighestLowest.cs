namespace HighestLowest.Juan
{
    public class HighestLowestJuan
    {
        static public String highest_lowest(String user_input)
        {
            var values = string_to_int_list(user_input, " ");
            return (String.Format("{0} {1}", values.Max(), values.Min()));
        }

        static public int[] string_to_int_list(String str, String separator)
        {
            return Array.ConvertAll(str.Split(separator), value => Int32.Parse(value));
        }
    }
}
