namespace Poker.Joaquin;
using Player.Joaquin;

public class PokerClass 
{
    // ADD PLAYER CLASS
    PlayerClass Black = new PlayerClass();
    PlayerClass White = new PlayerClass();

    // SHOULD CREATE CARD CLASS????
    char[] suits = {'C', 'D', 'H', 'S'};
    char[] values = {'2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};

    // METHOD TO RETURN DEAL CARD RESULT
    public string GetDealCardsResult(string blackHand, string whiteHand)
    {
        return "res";
    }

    // METHOD TO GET HAND RANKING (SHOULD CREATE RANKING CLASS????)
    public string GetHandRanking()
    {
        return "ranking";
    }
    
    // METHOD TO SHUFFLE AND DEAL CARDS (IS THIS NECESSARY ??)
    public string DealCardsToPlayer()
    {
        return "2H 3D 5S 9C KD";
    }

}