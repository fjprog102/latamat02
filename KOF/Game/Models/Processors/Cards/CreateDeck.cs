namespace KOT.Services.Processors;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Models.Processor;
public class PowerCardDeck
{
    public readonly List<PowerCard> Deck;
    public PowerCardDeck()
    {
        Deck = new List<PowerCard>();
        Deck.Add(new PowerCard("Alien Metabolism", 3, 0, new Effect(costReduction: 1))); //buying cards costs you 1 less
        Deck.Add(new PowerCard("Jet Fighters", 5, 1, new Effect(star: 5, damage: 4))); //"+ 5[Star] and take 4 damage"
        Deck.Add(new PowerCard("Apartament Building", 5, 1, new Effect(star: 3))); // + 3 stars
        Deck.Add(new PowerCard("Energize", 8, 1, new Effect(energy: 9))); // + 9 energy
        Deck.Add(new PowerCard("Heal", 3, 1,new Effect(heart: 2))); // heal 2 damage
        Deck.Add(new PowerCard("Skycraper", 6, 1, new Effect(star: 4))); // +4 stars
        Deck.Add(new PowerCard("Corner Store", 3, 1, new Effect(star: 1))); // +1 star
    }
}
