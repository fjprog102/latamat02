namespace PokerHands.Valeria
{
    public class Player
    {
        public string[] MyHand { get; set; }
        private readonly GamePlayRules Rules;
        public string MyBestPlay = "None";
        public Player(string[] hand)
        {
            MyHand = hand;
            Rules = new GamePlayRules(MyHand);
            Play();
        }
        private void Play()
        {
            PlayToWinStrategy();
            PlayBestValueStrategy();
            PlayBestSuitStrategy();
            PlayValuesStrategy();
            PlayForConsolationPrize();
        }
        public void PlayToWinStrategy()
        {
            MyBestPlay = Rules.ApplyStraightFlushRule();
        }
        public void PlayBestValueStrategy()
        {
            MyBestPlay = MyBestPlay.Equals("None") ? Rules.ApplyFourOfAKindRule() : MyBestPlay;
            MyBestPlay = MyBestPlay.Equals("None") ? Rules.ApplyFullHouseRule() : MyBestPlay;
        }
        public void PlayBestSuitStrategy()
        {
            MyBestPlay = MyBestPlay.Equals("None") ? Rules.ApplyFlushRule() : MyBestPlay;
            MyBestPlay = MyBestPlay.Equals("None") ? Rules.ApplyStraightRule() : MyBestPlay;
        }
        public void PlayValuesStrategy()
        {
            MyBestPlay = MyBestPlay.Equals("None") ? Rules.ApplyThreeOfAKindRule() : MyBestPlay;
            MyBestPlay = MyBestPlay.Equals("None") ? Rules.ApplyTwoPairsRule() : MyBestPlay;
            MyBestPlay = MyBestPlay.Equals("None") ? Rules.ApplyPairRule() : MyBestPlay;
        }
        public void PlayForConsolationPrize()
        {
            MyBestPlay = MyBestPlay.Equals("None") ? Rules.ApplyHighCardRule() : MyBestPlay;
        }
    }
}
