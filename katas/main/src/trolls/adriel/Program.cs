namespace Trolls.Adriel;
using System.Text.RegularExpressions;

public class TrollTrolls
{
    public string trollTheTrolls(string s)
    {
        Regex rx = new Regex("[a|e|i|o|u]", RegexOptions.IgnoreCase);
        return rx.Replace(s, "");
    }
}