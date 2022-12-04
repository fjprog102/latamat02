namespace KOT.Services.Processors;
using KOT.Models;
using KOT.Models.Abstracts;
public class PowerCardDeck
{
    public readonly List<PowerCard> Deck;
    public PowerCardDeck()
    {
        Deck = new List<PowerCard>();
        Deck.Add(new PowerCard("Alien Metabolism", 3, 0)); //buying cards costs you 1 less
        Deck.Add(new PowerCard("Alpha Monster", 5, 0)); //gain one star when you attack
        Deck.Add(new PowerCard("Apartament Building", 5, 1)); // + 3 stars
        Deck.Add(new PowerCard("Energize", 8, 1)); // + 9 energy
        Deck.Add(new PowerCard("Heal", 3, 1)); // heal 2 damage
        Deck.Add(new PowerCard("Skycraper", 6, 1)); // +4 stars
        Deck.Add(new PowerCard("Corner Store", 3, 1)); // +1 star
    }
}
