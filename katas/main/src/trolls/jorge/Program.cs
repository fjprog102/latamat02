namespace Trolls.Jorge;
using System.Text.RegularExpressions;
public class TrollsText
{
    public string Troll(string text)
    {
        return Regex.Replace(text, @"[aeiouAEIOUáéíóúÁÉÍÓÚ]", "");
    }
}
