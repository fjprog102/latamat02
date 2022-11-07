char[] user_input = Console.ReadLine().ToArray();

String opt = "";

foreach (char val in user_input)
{
    opt += get_square(val);
}
Console.WriteLine(opt);

String get_square(char value)
{
    int parsed = Int32.Parse(value.ToString());
    int square = parsed * parsed;
    return square.ToString();
}
