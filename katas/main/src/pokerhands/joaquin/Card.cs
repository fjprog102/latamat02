namespace PokerHand.Joaquin;

public class Card
{

    public char value;
    public char suit;
    public int weight;

    public Deck Deck = new Deck();

    public Card(char value, char suit)
    {
        Random index = new Random();
        this.value = char.ToUpper(value);
        this.suit = char.ToUpper(suit);
        this.weight = Deck.valuesRanking[this.value];
    }

    public string CreateCard()
    {
        return value.ToString() + suit.ToString();
    }
}