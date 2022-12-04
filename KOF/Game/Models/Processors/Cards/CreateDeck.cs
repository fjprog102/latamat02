namespace KOT.Services.Processors;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Models.Processor;
public class PowerCardDeck
{
    public List<CardDetails> Deck = new List<CardDetails>();
    public PowerCardDeck()
    {
        Deck.Add(new CardDetails(new PowerCard("Alien Metabolism", 3, 0), new Effect(costReduction: 1))); //buying cards costs you 1 less
        Deck.Add(new CardDetails(new PowerCard("Jet Fighters", 5, 1), new Effect(starPoints: 5, damagePoints: 4))); //"+ 5[Star] and take 4 damage"
        Deck.Add(new CardDetails(new PowerCard("Apartament Building", 5, 1), new Effect(starPoints: 3)));// + 3 stars
        Deck.Add(new CardDetails(new PowerCard("Energize", 8, 1), new Effect(energyPoints: 9))); // + 9 energy
        Deck.Add(new CardDetails(new PowerCard("Heal", 3, 1), new Effect(heartPoints: 2))); // heal 2 damage
        Deck.Add(new CardDetails(new PowerCard("Skycraper", 6, 1), new Effect(starPoints: 4))); // +4 stars
        Deck.Add(new CardDetails(new PowerCard("Corner Store", 3, 1), new Effect(starPoints: 1))); // +1 star
    }

    public Effect GetEffect(string powerCardName)
    {
        var powerCardEffect = from cardDetails in Deck where cardDetails.powerCard.Name == powerCardName select cardDetails.effect;
        return (Effect)powerCardEffect.ToList()[0];
    }
}
