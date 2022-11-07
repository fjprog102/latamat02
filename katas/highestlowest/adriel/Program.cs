System.Console.WriteLine("Type specific string:");
string input = Console.ReadLine();
string[] splitInput = input.Split(' ');

List<int> inputList = new List<int>();
foreach (string s in splitInput)
{
    inputList.Add(Convert.ToInt32(s));
}
inputList.Sort();

Console.WriteLine($"{inputList.Last()} {inputList.First()}");
