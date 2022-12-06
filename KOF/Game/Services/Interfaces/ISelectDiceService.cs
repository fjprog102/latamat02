using KOT.Models;
using KOT.Models.Abstracts;

namespace KOT.Services.Interfaces;

public interface ISelectDiceService
{
    public IEnumerable<KofDice> SelectDices(ChoosenDicePayload payload);
}
