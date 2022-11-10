namespace VowelCount.Juan
{
    public class VowelCountJuan
    {
        public static bool IsVowel(char val)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            return vowels.Contains(char.ToLower(val));
        }

        public static int CountVowels(string user_input)
        {
            char[] values = user_input.ToArray();
            int opt = 0;
            foreach (char val in values)
            {
                if (IsVowel(val))
                {
                    opt += 1;
                }
            }

            return opt;
        }
    }
}
