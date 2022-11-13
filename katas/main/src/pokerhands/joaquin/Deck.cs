namespace PokerHand.Joaquin;

public class Deck
{
    public string[] cards = new string[52];

    public char[] suits = {'C', 'D', 'H', 'S'};

    public char[] cardValues = {'2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};

    public Deck()
    {
        int index = 0;
        while (index < 52)
        {
            foreach(char suit in suits)
            {
                foreach(char value in cardValues)
                {
                    cards[index] = value.ToString() + suit.ToString();
                }
                index++;
            }
        }
  
    }
}