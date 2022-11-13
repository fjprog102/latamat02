namespace PokerHand.Joaquin;

public class HandRanking
{

    Dictionary<string, int> pokerRanking = new Dictionary<string, int>
    {
        {"high card", 0},
        {"pair", 1},
        {"two pairs", 2},
        {"three of a kind", 3},
        {"straight", 4},
        {"flush", 5},
        {"full house", 6},
        {"four of a kind", 7},
        {"straight flush", 8},
    };
    
    public string ranking = ""; 

    public bool IsStraightFlush(string[] hand)
    {
        return IsStraight(hand) && IsFlush(hand);
    }
    
    public bool IsFourOfAKind(string[] hand)
    {
        return true;
    }

    public bool IsFullHouse(string[] hand)
    {
        return true;
    }

    public bool IsFlush(string[] hand)
    {
        int count = 0;
        char suit = hand[0][1];
        foreach(string card in hand)
        {
            if(suit == card[1])
            {
                count++;
            }
        }
        if(count == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsStraight(string[] hand)
    {
        return true;
    }
}