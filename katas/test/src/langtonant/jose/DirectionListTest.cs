namespace LangtonAnt.Test.Jose;

using LangtonAnt.Jose;

public class DirectionListTest
{
    [Fact]
    private void DirectionListShouldInitializeArrayWithDefaultCurrent()
    {
        DirectionList directions = new DirectionList();
        Assert.Equal(Direction.West, directions.Current);
    }

    [Fact]
    private void DirectionListMoveToNextAndUpdateCurrent()
    {
        DirectionList directions = new DirectionList();

        Direction newCurrentDirection = directions.Next();
        Assert.Equal(Direction.North, newCurrentDirection);
        Assert.Equal(Direction.North, directions.Current);

        newCurrentDirection = directions.Next();
        Assert.Equal(Direction.East, newCurrentDirection);
        Assert.Equal(Direction.East, directions.Current);

        newCurrentDirection = directions.Next();
        Assert.Equal(Direction.South, newCurrentDirection);
        Assert.Equal(Direction.South, directions.Current);

        newCurrentDirection = directions.Next();
        Assert.Equal(Direction.West, newCurrentDirection);
        Assert.Equal(Direction.West, directions.Current);
    }
}
