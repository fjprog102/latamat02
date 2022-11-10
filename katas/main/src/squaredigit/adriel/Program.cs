namespace SquareDigit.Adriel;

public class SquareDigits
{
    public int squareEveryDigit(int num)
    {
        List<int> numberList = new List<int>();
        while (num != 0)
        {
            numberList.Insert(0, (num % 10) * (num % 10));
            num = num / 10;
        }

        return Convert.ToInt32(String.Join("", numberList));

    }
}
