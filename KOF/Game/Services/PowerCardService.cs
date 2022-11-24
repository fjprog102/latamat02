using KOF.Models;
using KOF.Models.Abstracts;
using KOF.Services.Interfaces;

namespace KOF.Services;

public class PowerCardService : IDataService
{
    private readonly List<PowerCard> cards = new List<PowerCard> { };

    IEnumerable<Element> IDataService.Read(DataHolder payload)
    {
        if (payload.Id != null)
        {
            return cards
                .Select(card => card)
                .Where(card => card.IdAttr!.Equals(payload.Id))
                .ToArray();
        }

        return new Element[0];
    }

    IEnumerable<Element> IDataService.Create(DataHolder payload)
    {
        if (payload.GetType().IsInstanceOfType(typeof(PowerCardPayload)))
        {
            PowerCardPayload args = (PowerCardPayload)payload;
            var newCard = new PowerCard((string)args.Name!, (int)args.Cost!, (int)args.Type!);
            cards.Append(newCard);
            return new Element[] { newCard };
        }

        return new Element[0];
    }

    IEnumerable<Element> IDataService.Delete(DataHolder payload)
    {
        if (payload.Id != null)
        {
            var card = cards
                .Select(card => card)
                .Where(card => card.IdAttr!.Equals(payload.Id))
                .ToArray();

            cards.Remove(card.First());

            return card;
        }

        return new Element[0];
    }

    IEnumerable<Element> IDataService.Update(DataHolder payload)
    {
        return new Element[0];
    }
}
