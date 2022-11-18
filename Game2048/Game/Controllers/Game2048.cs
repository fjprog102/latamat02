namespace Controllers;

using Models;

public class Game2048 : Game
{
    public Grid? grid;

    public Score? score;

    public override void Start()
    {
        grid = new Grid(4, 4);
        score = new Score2048();
    }

    public Game2048()
    {
        Start();
    }
}

