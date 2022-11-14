using CardJuan;
using HandJuan;

namespace PlayedHandJuan
{
    public static class PlayedHand
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
}
