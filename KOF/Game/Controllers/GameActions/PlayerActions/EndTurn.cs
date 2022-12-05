namespace KOT.Controllers;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class EndTurn : GameAction<EndTurn>
{
    public override void Execute(string[] dices, GamePayload game)
    {
        // Execute Player Power card (pending)

        int playerIndex = 0;
        for (int index = 0; index < game.Players!.Count(); index++)
        {
            if (game.ActivePlayerName == game.Players![index].Name)
            {
                playerIndex = index + 1;
            }
        }

        if (playerIndex == game.Players!.Count())
        {
            playerIndex = 0;
        }

        game.ActivePlayerName = game.Players![playerIndex].Name;
    }
}
