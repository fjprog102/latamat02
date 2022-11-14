namespace PokerHands.Cards.Adriel;

using Enums.Adriel;

public class Card
{
    public Value Value { get; }
    public Suit Suit { get; }

    public Card(string c)
    {
        char[] arr = c.ToLower().ToCharArray();
        if (arr.Length != 2) throw new ArgumentException("Card must only consist of value and suit");
        switch (arr[0])
        {
            case '2': this.Value = Value.Two; break;
            case '3': this.Value = Value.Three; break;
            case '4': this.Value = Value.Four; break;
            case '5': this.Value = Value.Five; break;
            case '6': this.Value = Value.Six; break;
            case '7': this.Value = Value.Seven; break;
            case '8': this.Value = Value.Eight; break;
            case '9': this.Value = Value.Nine; break;
            case '0': this.Value = Value.Ten; break;
            case 't': this.Value = Value.Ten; break;
            case 'j': this.Value = Value.Jack; break;
            case 'q': this.Value = Value.Queen; break;
            case 'k': this.Value = Value.King; break;
            case 'a': this.Value = Value.Ace; break;
            default: throw new ArgumentException($"Invalid value: '{arr[0]}'");
        }

        switch (arr[1])
        {
            case 's': this.Suit = Suit.Spades; break;
            case 'h': this.Suit = Suit.Hearts; break;
            case 'd': this.Suit = Suit.Diamonds; break;
            case 'c': this.Suit = Suit.Clubs; break;
            default: throw new ArgumentException($"Invalid suit: '{arr[1]}'");
        }
    }

    public int compareTo(Card other)
    {
        if (this.Value > other.Value) return 1;
        else if (this.Value < other.Value) return -1;
        return 0;
    }

    public override string ToString()
    {
        char[] values = "23456789TJQKA".ToCharArray();
        char[] suits = "cdhs".ToCharArray();
        //char[] suits = {  '♣', '♦', '♥', '♠' };

        return values[(int)Value].ToString() + suits[(int)Suit].ToString();
    }
}
