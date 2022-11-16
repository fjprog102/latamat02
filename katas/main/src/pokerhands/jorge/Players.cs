namespace PokerGame.Hands.Jorge;
using PokerGame.Dictionary.Jorge;
using PokerGame.Enums.Jorge;

public class GameBlackAndWhite
{
    public ResultsScore ResultsScore { get; }

    public string BothHands(string competitorsHand)
    {
        string[] blackHand = new Hand().HandStringToList(competitorsHand.Substring(7, 14));
        string[] whiteHand = new Hand().HandStringToList(competitorsHand.Substring(30, 14));

        if (int.Parse(blackHand[0]) == int.Parse(whiteHand[0]))
        {
            return
                new Dictionary().valueCards[blackHand[1]]
                > new Dictionary().valueCards[whiteHand[1]]
                ? "Black wins - with "
                    + (ResultsScore)int.Parse(blackHand[0])
                    + " and High Card of "
                    + blackHand[1]
                : "White wins - with "
                    + (ResultsScore)int.Parse(whiteHand[0])
                    + " and High Card of "
                    + whiteHand[1];
        }

        return int.Parse(blackHand[0]) > int.Parse(whiteHand[0])
            ? "Black wins - with " + (ResultsScore)int.Parse(blackHand[0]) + " of " + blackHand[1]
            : "White wins - with " + (ResultsScore)int.Parse(whiteHand[0]) + " of " + whiteHand[1];
    }
}
