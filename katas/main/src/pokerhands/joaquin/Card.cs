namespace PokerHand.Joaquin;

public class Card
{

    public char value;
    public char suit;
    public int weight;

    public Deck Deck = new Deck();

    public Card()
    {
        Random index = new Random();
        this.value = Deck.cardValues[index.Next(0, Deck.cardValues.Length)];
        this.suit = Deck.suits[index.Next(0, Deck.suits.Length)];
        this.weight = Deck.valuesRanking[this.value];
    }

    public string CreateCard()
    {
        // Random index = new Random();
        // this.value = Deck.cards[index.Next(0, Deck.cards.Length)];
        // return this.value;
        return value.ToString() + suit.ToString();
    }
}