namespace PokerHand.Joaquin;

public class Card
{

    public string value = ""; 

    public Deck Deck = new Deck();

    // public Card()
    // {
    //     Random index = new Random();
    //     this.value = Deck.cards[index.Next(0, Deck.cards.Length)];
    // }

    public string CreateCard()
    {
        Random index = new Random();
        this.value = Deck.cards[index.Next(0, Deck.cards.Length)];
        return this.value;
    }
}