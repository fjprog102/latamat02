namespace KOT.Models.Processor;
using KOT.Models;

public class PowerCardDeck
{
    public List<CardDetails> Deck = new List<CardDetails>();

    public PowerCardDeck()
    {
        Deck.Add(
            new CardDetails(
                new PowerCard("Jet Fighters", 5, 1),
                new Effect(starPoints: 5)
            )
        ); //"+ 5[Star] and take 4 damage"
        Deck.Add(
            new CardDetails(new PowerCard("Apartament Building", 5, 1), new Effect(starPoints: 3))
        ); // + 3 stars
        Deck.Add(new CardDetails(new PowerCard("Energize", 8, 1), new Effect(energyPoints: 9))); // + 9 energy
        Deck.Add(new CardDetails(new PowerCard("Heal", 3, 1), new Effect(heartPoints: 2))); // heal 2 damage
        Deck.Add(new CardDetails(new PowerCard("Skycraper", 6, 1), new Effect(starPoints: 4))); // +4 stars
        Deck.Add(new CardDetails(new PowerCard("Corner Store", 3, 1), new Effect(starPoints: 1))); // +1 star
    }

    public Effect GetEffect(string powerCardName)
    {
        var powerCardEffect =
            from cardDetails in Deck
            where cardDetails.powerCard.Name == powerCardName
            select cardDetails.effect;
        return (Effect)powerCardEffect.ToList()[0];
    }

    public List<CardDetails> GetFaceUpPowerCards()
    {
        List<CardDetails> faceUpPowerCards = new List<CardDetails>();
        while (faceUpPowerCards.Count < 3)
        {
            var random = new Random();
            int index = random.Next(Deck.Count);
            if (!faceUpPowerCards.Contains(Deck[index]))
            {
                faceUpPowerCards.Add(Deck[index]);
            }
        }

        return faceUpPowerCards;
    }
}
