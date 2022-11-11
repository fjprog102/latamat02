namespace LangtonAnt.Jose;

public class DirectionList
{
    public Direction Current { get; private set; }
    private readonly Direction[] _directions;
    private int _currentIndex;

    public DirectionList()
    {
        _directions = Enum.GetValues<Direction>();
    }

    public Direction Next()
    {
        _currentIndex++;
        _currentIndex %= _directions.Length;
        Current = _directions[_currentIndex];
        return Current;
    }

    public Direction Previous()
    {
        _currentIndex--;
        _currentIndex = _currentIndex < 0 ? _directions.Length - 1 : _currentIndex;
        Current = _directions[_currentIndex];
        return Current;
    }
}
