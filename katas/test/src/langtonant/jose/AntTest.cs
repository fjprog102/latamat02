namespace LangtonAnt.Test.Jose;

using LangtonAnt.Jose;

public class AntTest
{
    [Fact]
    private void AntShouldDefaultDirectionToWest()
    {
        Ant theAnt = new Ant();
        Assert.Equal(Direction.West, theAnt.Direction);
    }

    [Fact]
    private void AntShouldTurnRight()
    {
        Ant theAnt = new Ant();

        // Default initial direction is West, after turning 90° right, new direction should be North
        theAnt.TurnRight();
        Assert.Equal(Direction.North, theAnt.Direction);

        theAnt.TurnRight();
        Assert.Equal(Direction.East, theAnt.Direction);

        theAnt.TurnRight();
        Assert.Equal(Direction.South, theAnt.Direction);

        theAnt.TurnRight();
        Assert.Equal(Direction.West, theAnt.Direction);
    }
}
