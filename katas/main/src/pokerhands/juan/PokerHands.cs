using HandJuan;
using HandtypeCheckerJuan;
using PlayedHandJuan;

namespace PokerHandsJuan
{
    public class PlayHands
    {
        public static void PlayCurrentHand(Hand hand)
        {
            Func<bool>[] handPlayed =
            {
                () => HandTypeChecker.IsStraightFlush(hand),
                () => HandTypeChecker.IsFourOfAKind(hand),
                () => HandTypeChecker.IsFullHouse(hand),
                () => HandTypeChecker.IsFlush(hand),
                () => HandTypeChecker.IsStraight(hand),
                () => HandTypeChecker.IsThreeOfAKind(hand),
                () => HandTypeChecker.IsTwoPairs(hand),
                () => HandTypeChecker.IsPair(hand),
                () => HandTypeChecker.IsHighCard(hand),
            };
            for (int i = 0; i < handPlayed.Length; i++)
            {
                if (handPlayed[i]())
                {
                    hand.PlayedAttr = PlayedHand.GetCurrentHand(hand, i);
                    hand.RatingAttr = i;
                    hand.NameAttr = PlayedHand.GetHandName(i);
                    break;
                }
            }
        }

        public static string Play(string userInput)
        {
            List<Hand> players = GetPlayers(userInput);
            foreach (var player in players)
            {
                PlayCurrentHand(player);
            }

            return CompareCurrentHands(players);
        }

        public static string CompareCurrentHands(List<Hand> players)
        {
            if (IsTie(players))
            {
                if (IsFullTie(players))
                {
                    return GetTieMessage(players.ElementAt(0).NameAttr);
                }
                else
                {
                    return GetWinnerMessage(ChooseWinnerTie(players));
                }
            }

            return GetWinnerMessage(ChooseWinner(players));
        }

        public static string GetWinnerMessage(Hand hand)
        {
            return string.Format("Hand: {0}wins with a {1}", hand.HandString(), hand.NameAttr);
        }

        public static string GetTieMessage(string name)
        {
            return string.Format("Tie with a {0}", name);
        }

        public static Hand ChooseWinner(List<Hand> players)
        {
            if (players.ElementAt(0).RatingAttr < players.ElementAt(1).RatingAttr)
            {
                return players.ElementAt(0);
            }
            else
            {
                return players.ElementAt(1);
            }
        }

        public static Hand ChooseWinnerTie(List<Hand> players)
        {
            int pos = 0;
            for (int i = 4; i >= 0; i--)
            {
                if (
                    players.ElementAt(0).HandAttr.ElementAt(i).WeigthAttr
                    != players.ElementAt(1).HandAttr.ElementAt(i).WeigthAttr
                )
                {
                    pos = i;
                    break;
                }
            }

            return GetTieBreaker(players, pos);
        }

        public static Hand GetTieBreaker(List<Hand> players, int pos)
        {
            if (
                players.ElementAt(0).HandAttr.ElementAt(pos).WeigthAttr
                > players.ElementAt(1).HandAttr.ElementAt(pos).WeigthAttr
            )
            {
                return players.ElementAt(0);
            }
            else
            {
                return players.ElementAt(1);
            }
        }

        public static bool IsTie(List<Hand> players)
        {
            if (players.GroupBy(player => player.RatingAttr).ElementAt(0).Count() > 1)
            {
                return true;
            }

            return false;
        }

        public static bool IsFullTie(List<Hand> players)
        {
            for (int i = 0; i < players.ElementAt(0).HandAttr.Count(); i++)
            {
                if (
                    players.ElementAt(0).HandAttr.ElementAt(i).WeigthAttr
                    != players.ElementAt(1).HandAttr.ElementAt(i).WeigthAttr
                )
                {
                    return false;
                }
            }

            return true;
        }

        public static List<Hand> GetPlayers(string userInput)
        {
            List<Hand> players = new List<Hand>();
            foreach (string playerHand in userInput.Split("  "))
            {
                players.Add(new Hand(playerHand));
            }

            return players;
        }
    }
}
