using KOT.Models.Processor;

namespace KOT.Models.Test;

public class CardDetailsTest
{
    [Fact]
    public void ShouldReturnCardAndDefaultAttributes()
    {
        PowerCard MyPowerCard = new PowerCard("powercard1", 2, 0);
        Effect PowerCardEffect = new Effect();
        CardDetails MyCardDetails = new CardDetails(MyPowerCard, PowerCardEffect);

        Assert.Equal(MyPowerCard.Name, MyCardDetails.powerCard.Name);
        Assert.Equal(MyPowerCard.Cost, MyCardDetails.powerCard.Cost);
        Assert.Equal(MyPowerCard.Type, MyCardDetails.powerCard.Type);
        Assert.Equal(PowerCardEffect.HeartPoints, MyCardDetails.effect.HeartPoints);
        Assert.Equal(PowerCardEffect.CostReduction, MyCardDetails.effect.CostReduction);
        Assert.Equal(PowerCardEffect.StarPoints, MyCardDetails.effect.StarPoints);
        Assert.Equal(PowerCardEffect.EnergyPoints, MyCardDetails.effect.EnergyPoints);
        Assert.Equal(PowerCardEffect.DamagePoints, MyCardDetails.effect.DamagePoints);
    }
    [Fact]
        public void ShouldReturnCardAndAttributes()
    {
        PowerCard MyPowerCard = new PowerCard("Jet Fighters", 3, 0);
        Effect PowerCardEffect = new Effect(starPoints: 5, damagePoints: 4);
        CardDetails MyCardDetails = new CardDetails(MyPowerCard, PowerCardEffect);

        Assert.Equal(MyPowerCard.Name, MyCardDetails.powerCard.Name);
        Assert.Equal(MyPowerCard.Cost, MyCardDetails.powerCard.Cost);
        Assert.Equal(MyPowerCard.Type, MyCardDetails.powerCard.Type);
        Assert.Equal(PowerCardEffect.HeartPoints, MyCardDetails.effect.HeartPoints);
        Assert.Equal(PowerCardEffect.CostReduction, MyCardDetails.effect.CostReduction);
        Assert.Equal(PowerCardEffect.StarPoints, MyCardDetails.effect.StarPoints);
        Assert.Equal(PowerCardEffect.EnergyPoints, MyCardDetails.effect.EnergyPoints);
        Assert.Equal(PowerCardEffect.DamagePoints, MyCardDetails.effect.DamagePoints);
    }
}
