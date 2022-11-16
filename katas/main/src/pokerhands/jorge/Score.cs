namespace PokerGame.Score.Jorge;
using PokerGame.Dictionary.Jorge;
using PokerGame.Enums.Jorge;

public class ScoreGetter
{
    public string[] resultValues = new string[4]; // Array for results

    public string[] Score(
        double repeatedCards,
        string highestCard,
        string lowestCard,
        bool allSameSuit,
        int pairCount,
        string handScoreValue,
        List<string> pairArray
    )
    {
        var handScore = 0;
        // Conditionals to get score
        switch (repeatedCards)
        {
            case 1:
                handScoreValue = highestCard;
                handScore =
                    (
                        new Dictionary().valueCards[highestCard]
                            - new Dictionary().valueCards[lowestCard]
                        == 4
                    )
                        ? 5
                        : 1;
                break;
            case 2:
                handScore = 2;
                break;
            case 3:
                handScore = 4;
                break;
            case 4:
                handScore = 8;
                break;
        }

        if (allSameSuit)
        {
            handScore =
                (
                    new Dictionary().valueCards[highestCard]
                        - new Dictionary().valueCards[lowestCard]
                    == 4
                )
                    ? 9
                    : 6;
        }

        if (repeatedCards == 3 && pairCount == 1) // if full house
        {
            handScore = 7;
        }

        var newPairArray = pairArray.ToArray();
        Array.Sort(newPairArray);
        if (pairCount == 2) // if two pairs
        {
            handScore = 3;
            handScoreValue = newPairArray[1].ToString();
        }

        resultValues[0] = handScore.ToString();
        resultValues[1] = handScoreValue;
        resultValues[2] = newPairArray.Length > 0 ? newPairArray[0].ToString() : "0";
        resultValues[3] = highestCard;

        return resultValues;
    }
}
