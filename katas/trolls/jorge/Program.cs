namespace Trolls.Jorge;
using System.Text.RegularExpressions;
public class Trolls{
    public string IsTrolls(string text) {
        return Regex.Replace(text, @"[aeiouAEIOUáéíóúÁÉÍÓÚ]", "");
    }
}
