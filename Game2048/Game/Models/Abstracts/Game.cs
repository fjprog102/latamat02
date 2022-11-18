namespace Models;

public abstract class Game
{
    public Score score = new Score();

    public abstract void Start();

}
