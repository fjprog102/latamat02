namespace PokerGame.Hands.Jorge;

public class PokerGameBlackAndWhite
{
    public string BothHands(string competitorsHand)
    {
        double blackHand = new PokerHand().HandToPlay(competitorsHand.Substring(7, 14));
        double whiteHand = new PokerHand().HandToPlay(competitorsHand.Substring(30, 14));

        return blackHand > whiteHand
            ? "Black wins - with " + resultsScore[blackHand]
            : "White wins - with " + resultsScore[whiteHand];
    }

    public Dictionary<double, string> resultsScore = new Dictionary<double, string>
    {
        { 0, "ERROR!" },
        { 1, "Highcard" },
        { 2, "Pair" },
        { 2.1, "Two Pairs" },
        { 3, "Three of a kind" },
        { 3.1, "Straight" },
        { 3.2, "Flush" },
        { 3.3, "Full House" },
        { 4, "Four of a kind" },
        { 5, "Straight Flush" }
    };
}
