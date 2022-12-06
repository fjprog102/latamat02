using KOT.Models.Abstracts;

namespace KOT.Models;

public class ChoosenDicePayload : DataHolder
{
    public bool[] Choosen { get; set; }

    public KofDice Dices { get; set; }

    public ChoosenDicePayload(bool[] choosen, KofDice dices)
    {
        Choosen = choosen;
        Dices = dices;
    }
}
