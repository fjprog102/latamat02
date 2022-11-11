namespace Trolls.Joaquin
{
    public class TrollsText
    {
        public string RemoveVowels(string input)
        {
            string output = "";
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            for (int i = 0; i < input.Length; i++)
            {
                if (!vowels.Contains(char.ToLower(input[i])))
                {
                    output += input[i];
                }
            }

            return output;
        }
    }
}
