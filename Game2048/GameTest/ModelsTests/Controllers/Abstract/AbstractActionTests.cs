using Actions.Movements;
using Models;

namespace ActionsTests
{
    public static class ActionTestHelper
    {
        public static bool AreEqualGrids(Grid input, Grid expected)
        {
            for (int i = 0; i < input.Rows; i++)
            {
                for (int j = 0; i < input.Columns; i++)
                {
                    if (!AreEqualTile(input, expected, i, j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool AreEqualTile(Grid input, Grid expected, int indexA, int indexB)
        {
            if (expected.Cells[indexA, indexB] == null)
            {
                if (input.Cells[indexA, indexB] != null)
                {
                    return false;
                }
            }
            else
            {
                if (input.Cells[indexA, indexB] == null)
                {
                    return false;
                }

                if (expected.Cells[indexA, indexB]!.Value != input.Cells[indexA, indexB]!.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool AreEqualLists(List<Tile?> input, List<Tile?> expected)
        {
            for (int i = 0; i < expected.Count(); i++)
            {
                if (expected.ElementAt(i) != null)
                {
                    if (input.ElementAt(i)!.Value != expected.ElementAt(i)!.Value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    public class AbstractActionTest
    {
        public Tile[] mockList = new Tile[4];

        [Fact]
        public void TestIsEmpty()
        {
            var action = new MoveDown();
            List<Tile?> values = new List<Tile?>(mockList);
            Assert.True(action.Instance.IsEmpty(values, 0));
        }

        [Fact]
        public void TestIsSameValueTrue()
        {
            var action = new MoveDown();
            List<Tile?> values = new List<Tile?> { new Tile(2), new Tile(2), null, null };
            Assert.True(action.Instance.IsSameValue(values, 0, 1));
        }

        [Fact]
        public void TestIsSameValueFalse()
        {
            var action = new MoveDown();
            List<Tile?> values = new List<Tile?> { new Tile(2), new Tile(4), null, null };
            Assert.True(!action.Instance.IsSameValue(values, 0, 1));
        }

        [Fact]
        public void TestIsMergeList()
        {
            var action = new MoveDown();
            List<Tile?> values = new List<Tile?> { null, new Tile(2), new Tile(2), new Tile(2) };

            values = action.MergeList(values);

            List<Tile?> expected = new List<Tile?> { null, new Tile(2), null, new Tile(4) };

            for (int i = 0; i < values.Count(); i++)
            {
                if (expected.ElementAt(i) != null)
                {
                    Assert.Equal(values.ElementAt(i)!.Value, expected.ElementAt(i)!.Value);
                }
            }
        }

        [Fact]
        public void TestMoveList()
        {
            var action = new MoveDown();
            List<Tile?> values = new List<Tile?> { null, new Tile(2), new Tile(4), null };

            values = action.MoveList(values);

            List<Tile?> expected = new List<Tile?> { null, null, new Tile(2), new Tile(4) };

            for (int i = 0; i < values.Count(); i++)
            {
                if (expected.ElementAt(i) != null)
                {
                    Assert.Equal(values.ElementAt(i)!.Value, expected.ElementAt(i)!.Value);
                }
            }
        }

        [Fact]
        public void TestGetRow()
        {
            var gridMock = new Grid(2, 2);

            gridMock.InsertElement(0, 0, new Tile(2));
            gridMock.InsertElement(0, 1, new Tile(4));
            gridMock.InsertElement(1, 0, new Tile(8));
            gridMock.InsertElement(1, 1, new Tile(16));

            var action = new MoveDown();
            var row = action.Instance.GetRow(gridMock, 0).ToList();
            var expected = new List<Tile?> { new Tile(2), new Tile(4) };

            var row2 = action.Instance.GetRow(gridMock, 1).ToList();
            var expected2 = new List<Tile?> { new Tile(8), new Tile(16) };

            Assert.True(ActionTestHelper.AreEqualLists(row, expected));
            Assert.True(ActionTestHelper.AreEqualLists(row2, expected2));
        }

        [Fact]
        public void TestGetColumn()
        {
            var gridMock = new Grid(2, 2);

            gridMock.InsertElement(0, 0, new Tile(2));
            gridMock.InsertElement(0, 1, new Tile(4));
            gridMock.InsertElement(1, 0, new Tile(8));
            gridMock.InsertElement(1, 1, new Tile(16));

            var action = new MoveDown();
            var row = action.Instance.GetColumn(gridMock, 0).ToList();
            var expected = new List<Tile?> { new Tile(2), new Tile(8) };

            var row2 = action.Instance.GetColumn(gridMock, 1).ToList();
            var expected2 = new List<Tile?> { new Tile(4), new Tile(16) };

            Assert.True(ActionTestHelper.AreEqualLists(row, expected));
            Assert.True(ActionTestHelper.AreEqualLists(row2, expected2));
        }

        [Fact]
        public void TestSetRow()
        {
            var gridMock = new Grid(2, 2);

            var action = new MoveDown();
            var row = new List<Tile?> { new Tile(2), new Tile(4) };

            action.Instance.SetRow(gridMock, row, 0);

            var expected = new Grid(2, 2);

            expected.InsertElement(0, 0, new Tile(2));
            expected.InsertElement(0, 1, new Tile(4));

            Assert.True(ActionTestHelper.AreEqualGrids(gridMock, expected));
        }

        [Fact]
        public void TestSetColumn()
        {
            var gridMock = new Grid(2, 2);

            var action = new MoveDown();
            var column = new List<Tile?> { new Tile(2), new Tile(4) };

            action.Instance.SetColumn(gridMock, column, 0);

            var expected = new Grid(2, 2);

            expected.InsertElement(0, 0, new Tile(2));
            expected.InsertElement(1, 0, new Tile(4));

            Assert.True(ActionTestHelper.AreEqualGrids(gridMock, expected));
        }
    }
}
