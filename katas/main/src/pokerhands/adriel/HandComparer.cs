namespace PokerHands.HandsComparer.Adriel;

using Cards.Adriel;
using Enums.Adriel;
using Hands.Adriel;
using HandsEvaluator.Adriel;

public class HandComparer
{
    public string PlayerOneName { get; }
    public HandEvaluator PlayerOneHand { get; }
    public string PlayerTwoName { get; }
    public HandEvaluator PlayerTwoHand { get; }

    public HandComparer(string inputString)
    {
        PlayerOneName = GetPlayerOneData(inputString).First();
        PlayerOneHand = new HandEvaluator(new Hand(GetPlayerOneData(inputString).Last()));

        PlayerTwoName = GetPlayerTwoData(inputString).First();
        PlayerTwoHand = new HandEvaluator(new Hand(GetPlayerTwoData(inputString).Last()));
    }

    private static string[] GetPlayerOneData(string data)
    {
        return data.Split("  ").First().Split(": ");
    }

    private static string[] GetPlayerTwoData(string data)
    {
        return data.Split("  ").Last().Split(": ");
    }

    private int TieBreaker()
    {
        for (int i = PlayerOneHand.RankingCards.Length - 1; i >= 0; i--)
        {
            System.Console.WriteLine(i);
            if (PlayerOneHand.RankingCards[i].Value - PlayerTwoHand.RankingCards[i].Value == 0)
            {
                continue;
            }

            return PlayerOneHand.RankingCards[i].Value - PlayerTwoHand.RankingCards[i].Value;
        }

        return 0;
    }

    private string CreateFinalMessage(string name, HandEvaluator hand)
    {
        string[] rankings = { "High card", "Pair", "Two pairs", "Three of a kind",
            "Straight", "Flush", "Full house", "Four of a kind", "Straight flush"};

        string finalMessage = $"{name} wins! with {rankings[(int)hand.Ranking]}: ";

        if (hand.Ranking == Ranking.FullHouse)
        {
            finalMessage += $"{hand.RankingCards.Last().ToString().First()} over " +
            hand.RankingCards.First().ToString().First();
        }
        else
        {
            finalMessage += string.Join<Card>(" ", hand.RankingCards);
        }

        return finalMessage;
    }

    public string StartRound()
    {
        string output;
        if (PlayerOneHand.Ranking > PlayerTwoHand.Ranking)
        {
            output = CreateFinalMessage(PlayerOneName, PlayerOneHand);
        }
        else if (PlayerOneHand.Ranking < PlayerTwoHand.Ranking)
        {
            output = CreateFinalMessage(PlayerTwoName, PlayerTwoHand);
        }
        else if (TieBreaker() > 0)
        {
            output = CreateFinalMessage(PlayerOneName, PlayerOneHand);
        }
        else if (TieBreaker() < 0)
        {
            output = CreateFinalMessage(PlayerTwoName, PlayerTwoHand);
        }
        else
        {
            output = "Tie!";
        }

        return output;
    }
}
