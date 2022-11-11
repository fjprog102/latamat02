namespace Trolls.Adriel;
using System.Text.RegularExpressions;

public class TrollTrolls
{
    public string TrollTheTrolls(string s)
    {
        Regex rx = new Regex("[a|e|i|o|u]", RegexOptions.IgnoreCase);
        return rx.Replace(s, "");
    }
}
