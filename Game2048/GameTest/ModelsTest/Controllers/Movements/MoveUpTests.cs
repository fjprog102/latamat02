using Actions;
using Actions.Movements;
using Models;

namespace ActionsTests
{
    public class MoveUpTest
    {
        [Fact]
        public void TestMoveUpIsChildInstance()
        {
            var instance = new MoveUp();
            Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(AbstractAction<MoveUp>)));
        }

        [Fact]
        public void TestMoveUpExecute()
        {
            var gridMock = new Grid(2, 2);

            gridMock.InsertElement(0, 0, new Tile(2));
            gridMock.InsertElement(1, 1, new Tile(4));

            var expected = new Grid(2, 2);

            expected.InsertElement(0, 0, new Tile(2));
            expected.InsertElement(0, 1, new Tile(4));

            var action = new MoveUp();
            action.Instance.Execute(gridMock);

            Assert.True(ActionTestHelper.AreEqualGrids(gridMock, expected));
        }
    }
}
