namespace Trolls.Juan
{
    public class TrollsJuan
    {
        static public String trolls(String user_input)
        {
            char[] values = user_input.ToArray();
            String opt = "";
            foreach (char val in values)
            {
                if (!is_vowel(val))
                {
                    opt += val.ToString();
                }
            }

            return (opt);
        }

        static public bool is_vowel(Char val)
        {
            Char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            return vowels.Contains(Char.ToLower(val));
        }
    }
}
