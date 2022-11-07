char[] user_input = Console.ReadLine().ToArray();
Int32 opt = 0;
foreach (char val in user_input)
{
    if (is_vowel(val))
    {
        opt += 1;
    }
}

Console.WriteLine(opt);

bool is_vowel(Char val)
{
    Char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

    return vowels.Contains(Char.ToLower(val));
}
