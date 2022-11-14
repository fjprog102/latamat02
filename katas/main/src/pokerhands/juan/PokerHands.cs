namespace PokerHands.Juan
{
    public class Card
    {
        private readonly char suit;
        private readonly char value;
        private readonly int weigth;

        public Card(string input)
        {
            value = input[0];
            suit = input[1];
            weigth = ParsedValue(value);
        }

        public char SuitAttr => suit;
        public char ValueAttr => value;
        public int WeigthAttr => weigth;

        private int ParsedValue(char value)
        {
            char[] values = { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K' };
            return Array.IndexOf(values, value) + 1;
        }

        public string ToStr()
        {
            return string.Format("suit:{0} value:{1} weigth:{2}", suit, value, weigth);
        }
    }

    public static class GetHandType
    {
        public static bool IsStraightFlush(Hand hand)
        {
            return IsStraight(hand) && IsFlush(hand);
        }

        public static bool IsFourOfAKind(Hand hand)
        {
            if (hand.GroupsAttr.Count() == 2)
            {
                return (
                    hand.GroupsAttr.ElementAt(0).Count() == 4
                    || hand.GroupsAttr.ElementAt(0).Count() == 1
                );
            }

            return false;
        }

        public static bool IsFullHouse(Hand hand)
        {
            if (hand.GroupsAttr.Count() == 2)
            {
                return (
                    hand.GroupsAttr.ElementAt(0).Count() == 2
                    || hand.GroupsAttr.ElementAt(0).Count() == 3
                );
            }

            return false;
        }

        public static bool IsFlush(Hand hand)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (hand.HandAttr[i].SuitAttr != hand.HandAttr[i - 1].SuitAttr)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsStraight(Hand hand)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (hand.HandAttr[i].WeigthAttr - hand.HandAttr[i - 1].WeigthAttr != 1)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsThreeOfAKind(Hand hand)
        {
            if (hand.GroupsAttr.Count() == 3)
            {
                foreach (var group in hand.GroupsAttr)
                {
                    if (group.Count() > 2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsTwoPairs(Hand hand)
        {
            if (hand.GroupsAttr.Count() == 3)
            {
                foreach (var group in hand.GroupsAttr)
                {
                    if (group.Count() > 2)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public static bool IsPair(Hand hand)
        {
            return (hand.GroupsAttr.Count() == 4) ? true : false;
        }

        public static bool IsHighCard(Hand hand)
        {
            return (hand.GroupsAttr.Count() == 5);
        }
    }

    public static class GetPlayedHand
    {
        public static List<Card> GetStraightFlush(Hand hand)
        {
            return hand.HandAttr;
        }

        public static List<Card> GetFourOfAKind(Hand hand)
        {
            var group = hand.GroupsAttr.Where(subgroup => subgroup.Count() == 4);
            return group.ElementAt(0).ToList();
        }

        public static List<Card> GetFullHouse(Hand hand)
        {
            return hand.HandAttr;
        }

        public static List<Card> GetFlush(Hand hand)
        {
            return hand.HandAttr;
        }

        public static List<Card> GetStraigth(Hand hand)
        {
            return hand.HandAttr;
        }

        public static List<Card> GetThreeOfAKind(Hand hand)
        {
            var group = hand.GroupsAttr.Where(subgroup => subgroup.Count() == 3);
            return group.ElementAt(0).ToList();
        }

        public static List<Card> GetTwoPairs(Hand hand)
        {
            var group = hand.GroupsAttr.Where(subgroup => subgroup.Count() == 2);
            return group.SelectMany(subgroup => subgroup).ToList();
        }

        public static List<Card> GetPair(Hand hand)
        {
            var group = hand.GroupsAttr.Where(subgroup => subgroup.Count() == 2);
            return group.SelectMany(subgroup => subgroup).ToList();
        }

        public static List<Card> GetHighest(Hand hand)
        {
            if (hand.GroupsAttr.ElementAt(0).ElementAt(0).WeigthAttr == 1)
            {
                return hand.GroupsAttr.ElementAt(0).ToList();
            }
            else
            {
                return hand.GroupsAttr.ElementAt(4).ToList();
            }
        }

        public static List<Card> GetCurrentHand(Hand hand, int pos)
        {
            Func<List<Card>>[] playedHand =
            {
                () => GetStraightFlush(hand),
                () => GetFourOfAKind(hand),
                () => GetFullHouse(hand),
                () => GetFlush(hand),
                () => GetStraigth(hand),
                () => GetThreeOfAKind(hand),
                () => GetTwoPairs(hand),
                () => GetPair(hand),
                () => GetHighest(hand),
            };
            return playedHand[pos]();
        }

        public static string GetHandName(int pos)
        {
            string[] hands =
            {
                "Straigth flush",
                "Four of a kind",
                "Full house",
                "Flush",
                "Straigth",
                "Three of a kind",
                "Two pairs",
                "Pair",
                "High card"
            };
            return hands[pos];
        }
    }

    public class PlayHands
    {
        public static void PlayCurrentHand(Hand hand)
        {
            Func<bool>[] handPlayed =
            {
                () => GetHandType.IsStraightFlush(hand),
                () => GetHandType.IsFourOfAKind(hand),
                () => GetHandType.IsFullHouse(hand),
                () => GetHandType.IsFlush(hand),
                () => GetHandType.IsStraight(hand),
                () => GetHandType.IsThreeOfAKind(hand),
                () => GetHandType.IsTwoPairs(hand),
                () => GetHandType.IsPair(hand),
                () => GetHandType.IsHighCard(hand),
            };
            for (int i = 0; i < handPlayed.Length; i++)
            {
                if (handPlayed[i]())
                {
                    hand.PlayedAttr = GetPlayedHand.GetCurrentHand(hand, i);
                    hand.RatingAttr = i;
                    hand.NameAttr = GetPlayedHand.GetHandName(i);
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

    public class Hand
    {
        private readonly List<Card> cards = new List<Card>();
        private readonly IEnumerable<IGrouping<int, PokerHands.Juan.Card>> groups;

        private List<Card> played;
        private int rating;
        private string name;

        public Hand(string input)
        {
            foreach (string cardInfo in input.Split(" "))
            {
                cards.Add(new Card(cardInfo));
            }

            cards = cards.OrderBy(obj => obj.WeigthAttr).ToList();
            groups = cards.GroupBy(obj => obj.WeigthAttr);
        }

        public string ToStr()
        {
            string opt = "";
            foreach (Card card in cards)
            {
                opt += card.ToStr() + "  ";
            }

            return opt;
        }

        public string HandString()
        {
            string opt = "";
            foreach (Card card in cards)
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString() + " ";
            }

            return opt;
        }

        public List<Card> HandAttr => cards;
        public IEnumerable<IGrouping<int, PokerHands.Juan.Card>> GroupsAttr => groups;
        public List<Card> PlayedAttr
        {
            set => played = value;
        }
        public int RatingAttr
        {
            get => rating;
            set => rating = value;
        }
        public string NameAttr
        {
            get => name;
            set => name = value;
        }
    }
}
