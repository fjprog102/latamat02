using System;
using System.Text.RegularExpressions;

string trollTheTrolls(string s)
{
    Regex rx = new Regex("[a|e|i|o|u]", RegexOptions.IgnoreCase);
     return rx.Replace(s, "");
}

Console.WriteLine(trollTheTrolls("This website is for losers LOL!"));
Console.WriteLine(trollTheTrolls("This video is horrible!"));
Console.WriteLine(trollTheTrolls("Didn't like this at all!"));