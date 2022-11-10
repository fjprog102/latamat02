namespace VowelCount.Jorge;
using System.Text.RegularExpressions;
public class VowelCount{
    public int Phrase(string text) {
        var vowelCount = Regex.Replace(text, @"[^aeiouAEIOU]", "");
        return vowelCount.Length;
    }
}


