using System.Linq;

namespace PokerHands.Juan
{
    public class Card
    {
        private readonly char suit;
        private readonly char value;
        private readonly int weigth;

        public Card(char value, char suit)
        {
            this.suit = suit;
            this.value = value;
            weigth = ParsedValue(value);
        }

        public char SuitAttr => suit;
        public char ValueAttr => value;
        public int WeigthAttr => weigth;

        public string ToStr()
        {
            return string.Format("suit{0} value{1} weigth{2}", suit, value, weigth);
        }

        private int ParsedValue(char value)
        {
            try
            {
                return int.Parse(value.ToString());
            }
            catch
            {
                if (value == 'T')
                {
                    return 10;
                }

                if (value == 'J')
                {
                    return 11;
                }

                if (value == 'Q')
                {
                    return 12;
                }

                if (value == 'K')
                {
                    return 13;
                }

                if (value == 'A')
                {
                    return 1;
                }
            }

            return 0;
        }
    }

    public class Hand
    {
        private readonly List<Card> cards;

        public Hand(List<Card> cards)
        {
            this.cards = cards.OrderBy(obj => obj.WeigthAttr).ToList();
        }

        public List<Card> HandAttr => cards;

        public int GetHandRating()
        {
            if (IsStraightFlush())
            {
                return 9;
            }

            if (IsStraight())
            {
                return 5;
            }

            if (IsFlush())
            {
                return 6;
            }
            //Get group
            var groups = cards.GroupBy(obj => obj.WeigthAttr);
            int groupsSize = groups.Count();

            if (groupsSize == 2)
            {
                //Possible Four of a kind of full house
                if (groups.ElementAt(0).Count() == 4 || groups.ElementAt(0).Count() == 1)
                {
                    return 8; //Is four of a kind
                }
                else
                {
                    return 7; //Is full house
                }
            }

            if (groupsSize == 3)
            {
                //Possible three of a kind or two pairs
                foreach (var group in groups)
                {
                    if (group.Count() > 2)
                    {
                        return 4; //Is three of a kind
                    }
                }

                return 3; //Is two pairs
            }

            if (groupsSize == 4)
            {
                return 2; //Is pair
            }

            if (groupsSize == 5)
            {
                return 1; //Is high card
            }

            return 20;
        }

        private bool IsStraightFlush()
        {
            return IsStraight() && IsFlush();
        }

        private bool IsStraight()
        {
            for (int i = 1; i <= 4; i++)
            {
                if (cards[i].WeigthAttr - cards[i - 1].WeigthAttr != 1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsFlush()
        {
            for (int i = 1; i <= 4; i++)
            {
                if (cards[i].SuitAttr != cards[i - 1].SuitAttr)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Player
    {
        private readonly Hand hand;
        private readonly string name;

        private readonly int rating;

        public Player(Hand hand, string name)
        {
            this.hand = hand;
            this.name = name;
            rating = hand.GetHandRating();
        }

        public int RatingAttr => rating;
        public string NameAttr => name;
        public Hand HandAttr => hand;
    }

    public class PokerHandsJuan
    {
        private readonly List<Player> players = new List<Player>();

        public string PlayHands(string userInput)
        {
            CreateGame(userInput);

            string opt = "";

            foreach (Player player in players)
            {
                opt += string.Format(
                    "\nPlayer {0}, deck rate {1}",
                    player.NameAttr,
                    player.RatingAttr
                );

                foreach (Card card in player.HandAttr.HandAttr)
                {
                    opt += string.Format(
                        "\nSuit {0}, value {1}, weigth {2}",
                        card.SuitAttr,
                        card.ValueAttr,
                        card.WeigthAttr
                    );
                }
            }

            return opt;
        }

        private void CreateGame(string input)
        {
            foreach (string playerInfo in input.Split("  "))
            {
                players.Add(CreatePlayer(playerInfo.Split(" ", 2)));
            }
        }

        private Player CreatePlayer(string[] playerInfo)
        {
            return new Player(CreateHand(playerInfo[1]), playerInfo[0][0..^1]);
        }

        private Hand CreateHand(string cardsString)
        {
            List<Card> cards = new List<Card>();
            foreach (string cardInfo in cardsString.Split(" "))
            {
                cards.Add(CreateCard(cardInfo));
            }

            return new Hand(cards);
        }

        private Card CreateCard(string cardInfo)
        {
            return new Card(cardInfo[0], cardInfo[1]);
        }
    }
}
