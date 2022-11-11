namespace LangtonAnt.Jose;

using static Direction;

public class Ant
{
    public Direction Direction => _directionList.Current;

    private readonly DirectionList _directionList;

    public Ant()
    {
        _directionList = new DirectionList();
    }

    public void TurnRight()
    {
        _directionList.Next();
    }
}
