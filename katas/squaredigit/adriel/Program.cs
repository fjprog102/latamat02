int squareEveryDigit(int num)
{
    List<int> numberList = new List<int>();
    while (num != 0) {
        numberList.Insert(0, (num % 10) * (num % 10));
        num = num / 10;
    }

    return Convert.ToInt32(String.Join("", numberList));

}

System.Console.WriteLine(squareEveryDigit(123));
System.Console.WriteLine(squareEveryDigit(3451));
System.Console.WriteLine(squareEveryDigit(6321510));