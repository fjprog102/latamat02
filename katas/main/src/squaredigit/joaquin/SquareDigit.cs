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
                double squared = Math.Pow(Int32.Parse(c.ToString()), 2);
                result += squared.ToString();
            }
            return Int32.Parse(result);
        }
    }
}
