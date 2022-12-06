namespace KOT.Controllers.PowerCardsActions;
using KOT.Models;
using KOT.Services.Processors;
using KOT.Models.Processor;

public class PowerCardsAnalizer
{
    public void ExecuteEffect(Effect effect, Player player)
    {
        player.EnergyCubes += effect.EnergyPoints;
        player.MyMonster.VictoryPoints += effect.StarPoints;
        player.MyMonster.LifePoints += effect.HeartPoints;
        if(effect.DamagePoints > 0)
        {
            
        }
        if(effect.CostReduction > 0)
        {

        }
    }
    public void ResolveCards(Player player)
    {
        PowerCardDeck deck = new PowerCardDeck();
        if(player.PowerCards is not null && player.PowerCards.Count > 0)
        {
            foreach (var powerCard in player.PowerCards)
            {
                ExecuteEffect(deck.GetEffect(powerCard.Name), player);
            }
        }
    }
}
