namespace Poker.Joaquin;
using Player.Joaquin;

public class PokerClass 
{
    string input;
    // ADD PLAYER CLASS
    PlayerClass Black = new PlayerClass();
    PlayerClass White = new PlayerClass();

    // METHOD TO RETURN DEAL CARD RESULT
    public string GetHandWinner(string blackHand, string whiteHand)
    {
        return "res";
    }
    
    // METHOD TO SHUFFLE AND DEAL CARDS (IS THIS NECESSARY ??)
    public string DealCardsToPlayer()
    {
        return "2H 3D 5S 9C KD";
    }

}