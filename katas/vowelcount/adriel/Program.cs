using System;
using System.Text.RegularExpressions;

int vowelCount(string s)
{
    Regex rx = new Regex("[a|e|i|o|u]", RegexOptions.IgnoreCase);
     return rx.Matches(s).Count;
}

System.Console.WriteLine(vowelCount("aaaajjj"));
System.Console.WriteLine(vowelCount("akfjuehdgyua"));
System.Console.WriteLine(vowelCount("This is a test for the function"));