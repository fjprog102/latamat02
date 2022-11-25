namespace KOT.Models;

using KOT.Models.Abstracts;

public class KofDice : Dice
{
    public List<string>[] BlackDices = new List<string>[6];
    public List<string>[] GreenDices = new List<string>[2];

    public new string[] Symbols = { "one", "two", "three", "heart", "energy", "smash" };

    public KofDice()
    {
        foreach (string symbol in Symbols)
        {
            Faces.Add(symbol);
        }

        GenerateKofDices(BlackDices);
        GenerateKofDices(GreenDices);
    }

    public void GenerateKofDices(List<string>[] dices)
    {
        for (int index = 0; index < dices.Length; index++)
        {
            dices[index] = Faces;
        }
    }

    public List<string> RollDices(List<string>[] dices)
    {
        List<string> rolledDices = new List<string>();
        Random random = new Random();

        for (int index = 0; index < dices.Length; index++)
        {
            rolledDices.Add(dices[index][random.Next(dices[index].Count() - 1)]);
        }

        return rolledDices;
    }
}
