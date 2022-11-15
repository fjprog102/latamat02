namespace PokerGame.HandNumsGrouped.Jorge;
using System.Linq;
using PokerGame.Dictionary.Jorge;
using PokerGame.Score.Jorge;

public class PokerGameOrderList
{
    public List<string> pairArray = new List<string>(); // List to know pairs.

    internal string[] ListGroup(List<string> currentPokerHand)
    {
        //Know if all suits are the same
        bool allSameSuit =
            (
                from card in currentPokerHand
                group card by card[1] into newGroup
                let count = newGroup.Count()
                orderby count descending
                select new { Value = newGroup.Key, Count = count }
            )
                .ToList()
                .Count() == 1;

        //Get number of repeated values
        var handNums = (
            from card in currentPokerHand
            group card by card[0] into newGroup
            let count = newGroup.Count()
            orderby count descending
            select new { Value = newGroup.Key, Count = count }
        ).ToList();

        var repeatedCards = handNums.Max(card => card.Count);
        var handScoreValue = handNums[0].Value.ToString();
        var highestCard = new PokerDictionary().valueCards
            .FirstOrDefault(
                x =>
                    x.Value
                    == handNums.Max(card => new PokerDictionary().valueCards[card.Value.ToString()])
            )
            .Key;
        var lowestCard = new PokerDictionary().valueCards
            .FirstOrDefault(
                x =>
                    x.Value
                    == handNums.Min(card => new PokerDictionary().valueCards[card.Value.ToString()])
            )
            .Key;
        var pairCount = handNums.Count(x => x.Count == 2);
        foreach (var num in handNums)
        {
            if (num.Count == 2)
            {
                pairArray.Add(num.Value.ToString());
            }
        }

        return new PokerGameScoreGetter().Score(
            repeatedCards,
            highestCard,
            lowestCard,
            allSameSuit,
            pairCount,
            handScoreValue,
            pairArray
        );
    }
}
