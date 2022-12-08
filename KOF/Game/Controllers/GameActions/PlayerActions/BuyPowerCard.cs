namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;
using KOT.Models.Processor;

public class BuyPowerCard : GameAction<BuyPowerCard>
{
    public override void Execute(string[] dices, GamePayload game)
    {
        if (game.Board?.OutsideTokyo!.Exists(player => player.Name == game.ActivePlayerName) == true)
        {
            BuyCard(game.Board.OutsideTokyo.Find(player => player.Name == game.ActivePlayerName)!, game.Deck!);
        }

        if (game.Board?.TokyoCity!.Exists(player => player.Name == game.ActivePlayerName) == true)
        {
            BuyCard(game.Board.TokyoCity.Find(player => player.Name == game.ActivePlayerName)!, game.Deck!);
        }

        if (game.Board!.TokyoBay != null && game.Board?.TokyoBay!.Exists(player => player.Name == game.ActivePlayerName) == true)
        {
            BuyCard(game.Board.TokyoBay.Find(player => player.Name == game.ActivePlayerName)!, game.Deck!);
        }
    }

    public void BuyCard(Player player, PowerCardDeck deck)
    {
        for (int index = 0; index < deck!.Deck.Count(); index++)
        {
            if (player.EnergyCubes >= deck.Deck[index].powerCard.Cost)
            {
                player.EnergyCubes -= deck.Deck[index].powerCard.Cost;
                player.PowerCards!.Add(deck.Deck[index]);
                deck.Deck.Remove(deck.Deck[index]);
                break;
            }
        }
    }
}
