namespace KOT.Models;

using KOT.Models.Abstracts;

public class KofDice
{
    public string[] BlackDices = new string[6];
    public string[] GreenDices = new string[2];

    private readonly string[] Symbols = { "one", "two", "three", "heart", "energy", "smash" };

    public KofDice()
    {
        GenerateKofDices(BlackDices, new bool[] { false, false, false, false, false, false });
        GenerateKofDices(GreenDices, new bool[] { false, false });
    }

    public void GenerateKofDices(string[] instance, bool[] choosen)
    {
        for (int i = 0; i < instance.Count(); i++)
        {
            if (choosen[i] is false)
            {
                Random random = new Random();
                instance[i] = Symbols.ElementAt(random.Next(6));
            }
        }
    }
}
