namespace PokerHand.Joaquin;

public class Player
{
    public string name;
    public Hand Hand;
    public HandRanking HandRanking = new HandRanking();

    public Player(string name, Hand hand)
    {
        if (name.Length < 3)
        {
            throw new ArgumentException("Player name should be at least 3 characters.");
        }

        if (name.Length > 16)
        {
            throw new ArgumentException("Player name can't be longer than 15 characters.");
        }

        this.name = name;
        Hand = hand;
    }
}
