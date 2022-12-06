using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace KOT.Services;

public class SelectDiceService : ISelectDiceService
{
    public IEnumerable<KofDice> SelectDices(ChoosenDicePayload payload)
    {
        payload.Dices.GenerateKofDices(payload.Dices.BlackDices, payload.Choosen);
        return new List<KofDice> { payload.Dices };
    }
}
