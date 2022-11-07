char[] user_input = Console.ReadLine().ToArray();

char[] sorted = new char[user_input.Length];
Array.Copy(user_input, sorted, user_input.Length);

Array.Sort(sorted, new ReverseString());

String opt1 = char_list_to_string(user_input);
String opt2 = char_list_to_string(sorted);

Console.WriteLine(String.Format("Input: {0} Output: {1}", opt1, opt2));

String char_list_to_string(char[] arr)
{
    return new String(arr);
}

public class ReverseString : IComparer<char>
{
    public int Compare(char x, char y)
    {
        return y.CompareTo(x);
    }
}
