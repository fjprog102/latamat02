using HandJuan;

namespace HandtypeCheckerJuan
{
    public static class HandTypeChecker
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
}
