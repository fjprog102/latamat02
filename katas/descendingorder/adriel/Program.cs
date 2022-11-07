int descendingOrder(int number)
{
    char[] inputString = Convert.ToString(number).ToArray();

    Array.Sort(inputString);
    Array.Reverse(inputString);

    string resString = String.Join("", inputString);
    int res = Convert.ToInt32(resString);

    return (res);
}

System.Console.WriteLine(descendingOrder(6568161));
System.Console.WriteLine(descendingOrder(99541478));
System.Console.WriteLine(descendingOrder(4584151));
