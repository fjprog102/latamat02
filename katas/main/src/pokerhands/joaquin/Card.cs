namespace PokerHand.Joaquin;

public class Card
{

    public string cardValue = ""; 
    public char[] suits = {'C', 'D', 'H', 'S'};
    public char[] values = {'2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};

    public string CreateCard(char suit, char value)
    {
        cardValue = suit.ToString() + value.ToString();
        return cardValue;
    }
}