namespace PokerHands.Cards.Adriel;

using Enums.Adriel;

public class Card
{
    public Value Value { get; }
    public Suit Suit { get; }

    public Card(string cardString)
    {
        char[] valueAndSuitArray = cardString.ToLower().ToCharArray();
        if (valueAndSuitArray.Length != 2)
        {
            throw new ArgumentException("Card must only consist of value and suit");
        }

        switch (valueAndSuitArray.First())
        {
            case '2': Value = Value.Two; break;
            case '3': Value = Value.Three; break;
            case '4': Value = Value.Four; break;
            case '5': Value = Value.Five; break;
            case '6': Value = Value.Six; break;
            case '7': Value = Value.Seven; break;
            case '8': Value = Value.Eight; break;
            case '9': Value = Value.Nine; break;
            case '0': Value = Value.Ten; break;
            case 't': Value = Value.Ten; break;
            case 'j': Value = Value.Jack; break;
            case 'q': Value = Value.Queen; break;
            case 'k': Value = Value.King; break;
            case 'a': Value = Value.Ace; break;
            default: throw new ArgumentException($"Invalid value: '{valueAndSuitArray.First()}'");
        }

        switch (valueAndSuitArray.Last())
        {
            case 's': Suit = Suit.Spades; break;
            case 'h': Suit = Suit.Hearts; break;
            case 'd': Suit = Suit.Diamonds; break;
            case 'c': Suit = Suit.Clubs; break;
            default: throw new ArgumentException($"Invalid suit: '{valueAndSuitArray.Last()}'");
        }
    }

    public int CompareTo(Card other) => Value - other.Value;

    public override string ToString()
    {
        char[] values = "23456789TJQKA".ToCharArray();
        char[] suits = "cdhs".ToCharArray();
        //char[] suits = {  '♣', '♦', '♥', '♠' };

        return values[(int)Value].ToString() + suits[(int)Suit].ToString();
    }
}
