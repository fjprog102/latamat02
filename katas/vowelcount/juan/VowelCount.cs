namespace VowelCount.Juan
{
    public class VowelCountJuan
    {
        static public bool is_vowel(Char val)
        {
            Char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            return vowels.Contains(Char.ToLower(val));
        }

        static public int count_vowels(String user_input)
        {
            char[] values = user_input.ToArray();
            Int32 opt = 0;
            foreach (char val in values)
            {
                if (is_vowel(val))
                {
                    opt += 1;
                }
            }
            return opt;
        }
    }
}
