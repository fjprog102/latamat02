using KOT.Models.Processor;

namespace KOT.Models.Test;

public class CardDetailsTest
{
    [Fact]
    public void ShouldReturnCardAndDefaultAttributes()
    {
        PowerCard myPowerCard = new PowerCard("powercard1", 2, 0);
        Effect powerCardEffect = new Effect();
        CardDetails myCardDetails = new CardDetails(myPowerCard, powerCardEffect);

        Assert.Equal(myPowerCard.Name, myCardDetails.powerCard.Name);
        Assert.Equal(myPowerCard.Cost, myCardDetails.powerCard.Cost);
        Assert.Equal(myPowerCard.Type, myCardDetails.powerCard.Type);
        Assert.Equal(powerCardEffect.HeartPoints, myCardDetails.effect.HeartPoints);
        Assert.Equal(powerCardEffect.StarPoints, myCardDetails.effect.StarPoints);
        Assert.Equal(powerCardEffect.EnergyPoints, myCardDetails.effect.EnergyPoints);
        Assert.Equal(powerCardEffect.DamagePoints, myCardDetails.effect.DamagePoints);
    }
    [Fact]
    public void ShouldReturnCardAndAttributes()
    {
        PowerCard myPowerCard = new PowerCard("Jet Fighters", 3, 0);
        Effect powerCardEffect = new Effect(starPoints: 5, damagePoints: 4);
        CardDetails myCardDetails = new CardDetails(myPowerCard, powerCardEffect);

        Assert.Equal(myPowerCard.Name, myCardDetails.powerCard.Name);
        Assert.Equal(myPowerCard.Cost, myCardDetails.powerCard.Cost);
        Assert.Equal(myPowerCard.Type, myCardDetails.powerCard.Type);
        Assert.Equal(powerCardEffect.HeartPoints, myCardDetails.effect.HeartPoints);
        Assert.Equal(powerCardEffect.StarPoints, myCardDetails.effect.StarPoints);
        Assert.Equal(powerCardEffect.EnergyPoints, myCardDetails.effect.EnergyPoints);
        Assert.Equal(powerCardEffect.DamagePoints, myCardDetails.effect.DamagePoints);
    }
}
