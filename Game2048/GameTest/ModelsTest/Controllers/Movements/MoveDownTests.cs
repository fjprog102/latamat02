﻿using Actions;
using Actions.Movements;
using Models;

namespace ActionsTests
{
    public class MoveDownTest
    {
        [Fact]
        public void TestMoveDownIsChildInstance()
        {
            var instance = new MoveDown();
            Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(AbstractAction<MoveDown>)));
        }

        [Fact]
        public void TestMoveDownExecute()
        {
            var gridMock = new Grid(2, 2);

            gridMock.InsertElement(0, 0, new Tile(2));
            gridMock.InsertElement(1, 0, new Tile(2));
            gridMock.InsertElement(1, 1, new Tile(4));

            var expected = new Grid(2, 2);

            expected.InsertElement(1, 0, new Tile(4));
            expected.InsertElement(1, 1, new Tile(4));

            var action = new MoveDown();
            action.Instance.Execute(gridMock);

            Assert.True(ActionTestHelper.AreEqualGrids(gridMock, expected));
        }
    }
}
