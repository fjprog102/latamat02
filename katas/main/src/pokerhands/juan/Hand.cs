using CardJuan;

namespace HandJuan
{
    public class Hand
    {
        private readonly List<Card> cards = new List<Card>();
        private readonly IEnumerable<IGrouping<int, CardJuan.Card>> groups;

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
            string output = "";
            foreach (Card card in cards)
            {
                output += card.ToStr() + "  ";
            }

            return output;
        }

        public string HandString()
        {
            string output = "";
            foreach (Card card in cards)
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString() + " ";
            }

            return output;
        }

        public List<Card> HandAttr => cards;
        public IEnumerable<IGrouping<int, CardJuan.Card>> GroupsAttr => groups;
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
