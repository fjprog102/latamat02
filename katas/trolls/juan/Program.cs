char[] user_input = Console.ReadLine().ToArray();
String opt = "";
foreach (char val in user_input)
{
    if (!is_vowel(val))
    {
        opt += val.ToString();
    }
}

Console.WriteLine(opt);

bool is_vowel(Char val)
{
    Char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

    return vowels.Contains(Char.ToLower(val));
}
