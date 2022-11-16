namespace PokerHands.Joaquin;

public class Game
{
    public Player firstPlayer, secondPlayer;
    public Game(Player firstPlayer, Player secondPlayer)
    {
        this.firstPlayer = firstPlayer;
        this.secondPlayer = secondPlayer;
    }

    public string GetWinner(Player firstPlayer, Player secondPlayer)
    {
        firstPlayer.HandRanking.GetHandRanking(firstPlayer.Hand);
        secondPlayer.HandRanking.GetHandRanking(secondPlayer.Hand);
        if (firstPlayer.HandRanking.ranking > secondPlayer.HandRanking.ranking)
        {
            return $"{firstPlayer.name} wins with {firstPlayer.HandRanking.type}.";
        }
        else if (firstPlayer.HandRanking.ranking < secondPlayer.HandRanking.ranking)
        {
            return $"{secondPlayer.name} wins with {secondPlayer.HandRanking.type}.";
        }
        else
        {
            return EvaluateTie(firstPlayer, secondPlayer);
        }
    }

    public string EvaluateTie(Player firstPlayer, Player secondPlayer)
    {
        var orderedHandFirstPlayer = firstPlayer.HandRanking.OrderHandByCardWeight(firstPlayer.Hand);
        var orderedHandSecondPlayer = secondPlayer.HandRanking.OrderHandByCardWeight(secondPlayer.Hand);

        for (int index = 0; index < orderedHandFirstPlayer.Count(); index++)
        {
            if (orderedHandFirstPlayer[index].weight > orderedHandSecondPlayer[index].weight)
            {
                return $"{firstPlayer.name} wins with high card.";
            }
            else if (orderedHandFirstPlayer[index].weight < orderedHandSecondPlayer[index].weight)
            {
                return $"{secondPlayer.name} wins with high card.";
            }
        }

        return "Tie.";
    }
}
