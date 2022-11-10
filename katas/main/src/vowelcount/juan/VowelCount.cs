namespace VowelCount.Juan
{
    public class VowelCountJuan
    {
        public static bool is_vowel(char val)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            return vowels.Contains(char.ToLower(val));
        }

        public static int count_vowels(string user_input)
        {
            char[] values = user_input.ToArray();
            int opt = 0;
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
