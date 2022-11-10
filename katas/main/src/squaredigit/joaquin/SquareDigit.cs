namespace SquareDigit.Joaquin
{
    public class SquareDigitClass
    {
        public int squareDigits(int input)
        {
            string numbers = input.ToString();
            string result = "";

            foreach (char c in numbers)
            {
                double squared = Math.Pow(int.Parse(c.ToString()), 2);
                result += squared.ToString();
            }

            return int.Parse(result);
        }
    }
}
