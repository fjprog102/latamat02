namespace PokerGame.Hands.Jorge;
using System.Linq;
using PokerGame.HandNumsGrouped.Jorge;

public class PokerHand
{
    public string[] HandStringToList(string listPokerHand)
    {
        List<string> currentPokerHand = listPokerHand.Split().ToList();
        return new PokerGameOrderList().ListGroup((List<string>)currentPokerHand);
    }
}
