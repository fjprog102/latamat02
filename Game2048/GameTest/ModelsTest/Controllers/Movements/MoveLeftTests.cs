using Actions;
using Actions.Movements;
using Models;

namespace ActionsTests
{
    public class MoveLeftTest
    {
        [Fact]
        public void TestMoveLeftIsChildInstance()
        {
            var instance = new MoveLeft();
            Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(AbstractAction<MoveLeft>)));
        }

        [Fact]
        public void TestMoveLeftExecute()
        {
            var gridMock = new Grid(2, 2);

            gridMock.InsertElement(0, 0, new Tile(2));
            gridMock.InsertElement(1, 1, new Tile(4));

            var expected = new Grid(2, 2);

            expected.InsertElement(0, 0, new Tile(2));
            expected.InsertElement(1, 0, new Tile(4));

            var action = new MoveLeft();
            action.Instance.Execute(gridMock);

            Assert.True(ActionTestHelper.AreEqualGrids(gridMock, expected));
        }
    }
}
