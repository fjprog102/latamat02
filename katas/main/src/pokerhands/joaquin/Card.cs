namespace PokerHand.Joaquin;

public class Card
{

    public string value = ""; 
    public char[] suits = {'C', 'D', 'H', 'S'};
    public char[] cardValues = {'2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};

    public Card()
    {
        Random index = new Random();
        this.value = index.Next(0, suits.Length).ToString() + index.Next(0, cardValues.Length).ToString();
    }
}