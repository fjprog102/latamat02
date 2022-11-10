// See https://aka.ms/new-console-template for more information
namespace VowelCount.Joaquin
{
    public class VowelCountClass
    {
        public int vowelCount(string input)
        {
            int count = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            foreach (char ch in input)
            {
                if (vowels.Contains(ch))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
