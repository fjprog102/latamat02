using System.Text.Json;
using KOF.Models;
using KOF.Services.Interfaces;

namespace KOF.Services;

public class PowerCardService : IDataService
{
    private readonly List<PowerCard> cards = new List<PowerCard> { };

    ServiceResponse<DataHolder> IDataService.Read(string? id)
    {
        if (id != null)
        {
            return cards.Select(card => card).Where(card => card.IdAttr == id).ToArray();
        }

        return cards;
    }

    ServiceResponse<DataHolder> IDataService.Create(DataHolder data)
    {
        List<PowerCard> newCards = new List<PowerCard>();
        if (name != null)
        {
            cards.Add(new PowerCard(name, cost, type));
            newCards.Add(new PowerCard(name, cost, type));
        }

        return newCards;
    }

    public ServiceResponse<DataHolder> IDataService.Delete(DataHolder data)
    {
        return null;
    }

    public ServiceResponse<DataHolder> IDataService.Update(DataHolder data)
    {
        return null;
    }
}
