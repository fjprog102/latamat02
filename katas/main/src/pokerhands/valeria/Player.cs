using System.Text.RegularExpressions;

namespace PokerHands.Valeria
{
    public class Player
    {
        public string []MyHand { get; set; }

        public Player(string []hand)
        {
            MyHand = hand;
        }
    }
}
