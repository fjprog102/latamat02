System.Console.WriteLine("Type a non-negative number");
string input = Console.ReadLine();

long checkInt;
if(!long.TryParse(input, out checkInt) || checkInt < 0)
{
    System.Console.WriteLine("Only non-negative numbers accepted.");
    return;
}

char[] res = input.ToArray();
Array.Sort(res);
Array.Reverse(res);
String.Join("", res);

System.Console.WriteLine(res);