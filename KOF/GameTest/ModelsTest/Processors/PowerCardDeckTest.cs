namespace KOT.Models.Test;

using KOT.Models.Processor;

public class PowerCardDeckTest
{
    [Fact]
    public void ShouldReturnCardDetails()
    {
        PowerCardDeck powerCardDeck = new PowerCardDeck();
        Assert.IsType<CardDetails>(powerCardDeck.Deck.First());
    }

    [Fact]
    public void ShouldReturnEffectsForAPowerCard()
    {
        PowerCardDeck powerCardDeck = new PowerCardDeck();
        var heartPoints =
            from cardDetails in powerCardDeck.Deck
            where cardDetails.powerCard.Name == "Heal"
            select cardDetails.effect.LifePoints;
        Assert.Equal(2, heartPoints.ToList()[0]);
    }

    [Fact]
    public void ShouldReturnEffectsForAGivenPowerCardName()
    {
        PowerCardDeck powerCardDeck = new PowerCardDeck();
        Effect powerCardEffect = powerCardDeck.GetEffect("Heal");
        Assert.Equal(2, powerCardEffect.LifePoints);

        Effect powerCardEffect1 = powerCardDeck.GetEffect("Jet Fighters");
        Assert.Equal(5, powerCardEffect1.VictoryPoints);
    }
    [Fact]
    public void ShouldReturnThreeFaceUpPowerCards()
    {
        PowerCardDeck myDeck = new PowerCardDeck();
        List<CardDetails> faceUpPowerCards = myDeck.GetFaceUpPowerCards();
        Assert.Equal(3, faceUpPowerCards.Count);
    }
}
