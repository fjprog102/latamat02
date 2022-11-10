namespace Trolls.Juan
{
    public class TrollsJuan
    {
        public static string trolls(string user_input)
        {
            char[] values = user_input.ToArray();
            string opt = "";
            foreach (char val in values)
            {
                if (!is_vowel(val))
                {
                    opt += val.ToString();
                }
            }

            return (opt);
        }

        public static bool is_vowel(char val)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            return vowels.Contains(char.ToLower(val));
        }
    }
}
