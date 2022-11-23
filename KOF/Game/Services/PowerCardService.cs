using System.Text.Json;
using KOF.Models;
using KOF.Services.Interfaces;

namespace KOF.Services;

public class PowerCardService : IPowerCard
{
    private readonly List<PowerCard> cards = new List<PowerCard> { };

    IEnumerable<PowerCard> IPowerCard.GetMethod(string? id)
    {
        if (id != null)
        {
            return cards.Select(card => card).Where(card => card.IdAttr == id).ToArray();
        }

        return cards;
    }

    IEnumerable<PowerCard> IPowerCard.PostMethod(string? name, int cost, int type)
    {
        List<PowerCard> newCards = new List<PowerCard>();
        if (name != null)
        {
            cards.Add(new PowerCard(name, cost, type));
            newCards.Add(new PowerCard(name, cost, type));
        }

        return newCards;
    }
}
