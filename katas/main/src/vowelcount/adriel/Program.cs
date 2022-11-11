namespace VowelCount.Adriel;
using System.Text.RegularExpressions;

public class VowelCounter
{
    public int VowelCount(string s)
    {
        Regex rx = new Regex("[aeiou]", RegexOptions.IgnoreCase);
        return rx.Matches(s).Count;
    }
}
