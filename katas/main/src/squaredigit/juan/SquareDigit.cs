namespace SquareDigit.Juan
{
    public class SquareDigitJuan
    {
        public static string square_digit(string user_input)
        {
            string opt = "";

            foreach (char val in user_input)
            {
                opt += get_square(val);
            }

            return opt;
        }

        public static string get_square(char value)
        {
            int parsed = int.Parse(value.ToString());
            int square = parsed * parsed;
            return square.ToString();
        }
    }
}
