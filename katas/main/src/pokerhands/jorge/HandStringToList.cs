namespace PokerGame.Hands.Jorge;
using System.Linq;
using PokerGame.HandNumsGrouped.Jorge;

public class Hand
{
    public string[] HandStringToList(string listPokerHand)
    {
        List<string> currentPokerHand = listPokerHand.Split().ToList();
        return new OrderList().ListGroup((List<string>)currentPokerHand);
    }
}
