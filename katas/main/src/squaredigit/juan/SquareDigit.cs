namespace SquareDigit.Juan
{
    public class SquareDigitJuan
    {
        public static string SquareDigit(string user_input)
        {
            string opt = "";

            foreach (char val in user_input)
            {
                opt += GetSquare(val);
            }

            return opt;
        }

        public static string GetSquare(char value)
        {
            int parsed = int.Parse(value.ToString());
            int square = parsed * parsed;
            return square.ToString();
        }
    }
}
