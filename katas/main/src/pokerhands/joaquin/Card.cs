namespace PokerHand.Joaquin;

public class Card
{

    public char value;
    public char suit;
    public int weight;

    public Deck Deck = new Deck();

    public Card(char value, char suit)
    {
        this.value = char.ToUpper(value);
        this.suit = char.ToUpper(suit);
        weight = Deck.valuesRanking[value];
    }

    public string CardToString()
    {
        return value.ToString() + suit.ToString();
    }
}
