namespace PokerHands.Valeria
{
    public class Dealer 
    { 
        public Player WhitePlayer, BlackPlayer;
        public int BlackPlayerPoints = 0, WhitePlayerPoints = 0;
        Dictionary<string, int> PriorityRulesOrderList = new Dictionary<string, int>{{"with straight flush", 9}, {"with four of a kind", 8}, {"with full house", 7}, {"with flush", 6}, {"with straight", 5}, {"with three of a kind", 4}, {"with two pairs", 3}, {"with pair", 2}, {"with high card", 1}};
        string []Deck = {
            "AH", "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "JH", "QH", "KH",
            "AD", "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "JD", "QD", "KD",
            "AS", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "JS", "QH", "KH",
            "AC", "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "JC", "QH", "KH"};
        public Dealer()
        {
            List<string> BlackHand = GiveAHand();
            List<string> WhiteHand = GiveAHand();
            BlackPlayer = new Player(BlackHand.ToArray());
            WhitePlayer = new Player(WhiteHand.ToArray());
        }
        private int GetRandom()
        {
            Random generator = new Random();
            int random = generator.Next(1, 52);
            return random;
        }
        public List<string> GiveAHand()
        {
            List<string> Hand = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Hand.Add(Deck[GetRandom()]);
            }
            return Hand;
        }
        public void CalculatePointsForEachPlayer()
        {
            foreach (var rule in PriorityRulesOrderList)
            {
                BlackPlayerPoints = BlackPlayerPoints == 0? BlackPlayer.MyBestPlay.Contains(rule.Key)? rule.Value : BlackPlayerPoints :BlackPlayerPoints;
                WhitePlayerPoints = WhitePlayerPoints == 0? WhitePlayer.MyBestPlay.Contains(rule.Key)? rule.Value : WhitePlayerPoints : WhitePlayerPoints; 
            }
        }
        public string AnnounceWinner()
        {
            if(BlackPlayerPoints == WhitePlayerPoints) return "Tie.";
            return BlackPlayerPoints > WhitePlayerPoints? "Black wins. - " + BlackPlayer.MyBestPlay : "White wins. - " + WhitePlayer.MyBestPlay;
        }
    }
}
