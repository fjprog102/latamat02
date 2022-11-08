namespace SquareDigit.Juan
{
    public class SquareDigitJuan
    {
        static public String square_digit(String user_input)
        {
            char[] values = user_input.ToArray();
            String opt = "";

            foreach (char val in user_input)
            {
                opt += get_square(val);
            }
            return opt;
        }

        static public String get_square(char value)
        {
            int parsed = Int32.Parse(value.ToString());
            int square = parsed * parsed;
            return square.ToString();
        }
    }
}
