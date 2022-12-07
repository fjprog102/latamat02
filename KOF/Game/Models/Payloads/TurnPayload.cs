namespace KOT.Models;

using KOT.Models.Abstracts;

public class TurnPayload : DataHolder
{
    public string[] DiceResult { get; set; }

    public TurnPayload(
    string id,
    string[] diceResult
)
    {
        Id = id;
        DiceResult = diceResult;
    }
}
