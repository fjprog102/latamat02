namespace PokerHand.Joaquin;

public class Game
{
    public string firstPlayer, secondPlayer;
    public Hand firstPlayerHand, secondPlayerHand;

    public Game(string firstPlayer, Hand firstPlayerHand, string secondPlayer, Hand secondPlayerHand)
    {
        this.firstPlayer = firstPlayer;
        this.firstPlayerHand = firstPlayerHand;
        this.secondPlayer = secondPlayer;
        this.secondPlayerHand = secondPlayerHand;
    }
}