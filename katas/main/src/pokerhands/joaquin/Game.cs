namespace PokerHand.Joaquin;

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
        firstPlayer.HandRanking.GetRankingType(firstPlayer.HandRanking.ranking);
        secondPlayer.HandRanking.GetHandRanking(secondPlayer.Hand);
        secondPlayer.HandRanking.GetRankingType(secondPlayer.HandRanking.ranking);
        if(firstPlayer.HandRanking.ranking > secondPlayer.HandRanking.ranking) return $"{firstPlayer.name} wins with {firstPlayer.HandRanking.type}.";
        else if(firstPlayer.HandRanking.ranking < secondPlayer.HandRanking.ranking) return $"{secondPlayer.name} wins with {secondPlayer.HandRanking.type}.";
        else return EvaluateTie(firstPlayer, secondPlayer);
    }

    public string EvaluateTie(Player firstPlayer, Player secondPlayer)
    {
        var orderedHandFirstPlayer = firstPlayer.HandRanking.OrderHandByCardWeight(firstPlayer.Hand);   
        var orderedHandSecondPlayer = secondPlayer.HandRanking.OrderHandByCardWeight(secondPlayer.Hand); 
        for(int i = 0; i < orderedHandFirstPlayer.Length; i++)
        {
            if(orderedHandFirstPlayer[i] > orderedHandSecondPlayer[i]) return $"{firstPlayer.name} wins with high card.";
            else if(orderedHandFirstPlayer[i] < orderedHandSecondPlayer[i]) return $"{secondPlayer.name} wins with high card.";
        }  
        return "Tie.";
    }

    
}