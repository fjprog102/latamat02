namespace HighestLowest.Adriel;

public class HighestAndLowest
{
    public string getHighestAndLowest(string formattedString)
    {
        System.Console.WriteLine($"You entered: {formattedString}");
        string[] splitInput = formattedString.Split(' ');

        List<int> inputList = new List<int>();
        foreach (string s in splitInput)
        {
            inputList.Add(Convert.ToInt32(s));
        }

        return $"{inputList.Max()} {inputList.Min()}";

    }
}
