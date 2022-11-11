namespace Trolls.Juan
{
    public class TrollsJuan
    {
        public static string Trolls(string user_input)
        {
            char[] values = user_input.ToArray();
            string opt = "";
            foreach (char val in values)
            {
                if (!IsVowel(val))
                {
                    opt += val.ToString();
                }
            }

            return (opt);
        }

        public static bool IsVowel(char val)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            return vowels.Contains(char.ToLower(val));
        }
    }
}
