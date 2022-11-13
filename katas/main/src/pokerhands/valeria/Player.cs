using System.Text.RegularExpressions;

namespace PokerHands.Valeria
{
    public class Player
    {
        public String []MyHand { get; set; }

        public Player(String []Hand)
        {
            MyHand = Hand;
        }

    }
}
