namespace KOT.Services.Processors;
using KOT.Models;
using KOT.Models.Abstracts;
public class PowerCardDeck
{
    public readonly List<PowerCard> Deck;
    public PowerCardDeck()
    {
        Deck = new List<PowerCard>();
        Deck.Add(new PowerCard("Acid Attack", 6, 0));
        Deck.Add(new PowerCard("Alien Metabolism", 3, 0));
        Deck.Add(new PowerCard("Alpha Monster", 5, 0));
        Deck.Add(new PowerCard("Apartament Building", 5, 1));
        Deck.Add(new PowerCard("Armor Plating", 4, 0));
        Deck.Add(new PowerCard("Background Dweller", 4, 0));
        Deck.Add(new PowerCard("Burrowing", 5, 0));
        Deck.Add(new PowerCard("Camouflage", 3, 0));
        Deck.Add(new PowerCard("Commuter Train", 4, 1));
        Deck.Add(new PowerCard("Complete Destruction", 3, 0));
        Deck.Add(new PowerCard("Corner Store", 3, 1));
    }
}
