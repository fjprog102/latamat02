using Actions.Movements;
using Models;

namespace ActionsTests
{
    public class AbstractActionTest
    {
        public Tile[] mockList = new Tile[4];

        [Fact]
        public void TestIsEmpty()
        {
            var action = new MoveDown();
            List<Tile> values = new List<Tile>(mockList);
            Assert.True(action.Instance.IsEmpty(values, 0));
        }

        [Fact]
        public void TestIsSameValueTrue()
        {
            var action = new MoveDown();
            List<Tile> values = new List<Tile> { new Tile(2), new Tile(2), null, null };
            Assert.True(action.Instance.IsSameValue(values, 0, 1));
        }

        [Fact]
        public void TestIsSameValueFalse()
        {
            var action = new MoveDown();
            List<Tile> values = new List<Tile> { new Tile(2), new Tile(4), null, null };
            Assert.True(!action.Instance.IsSameValue(values, 0, 1));
        }

        [Fact]
        public void TestIsMergeRow()
        {
            var action = new MoveDown();
            List<Tile> values = new List<Tile> { null, new Tile(2), new Tile(2), new Tile(2) };

            values = action.MergeRow(values);

            List<Tile> expected = new List<Tile> { null, new Tile(2), null, new Tile(4) };

            for (int i = 0; i < values.Count(); i++)
            {
                if (expected.ElementAt(i) != null)
                {
                    Assert.Equal(values.ElementAt(i).Value, expected.ElementAt(i).Value);
                }
            }
        }

        [Fact]
        public void TestMoveRow()
        {
            var action = new MoveDown();
            List<Tile> values = new List<Tile> { null, new Tile(2), new Tile(4), null };

            values = action.MoveRow(values);

            List<Tile> expected = new List<Tile> { null, null, new Tile(2), new Tile(4) };

            for (int i = 0; i < values.Count(); i++)
            {
                if (expected.ElementAt(i) != null)
                {
                    Assert.Equal(values.ElementAt(i).Value, expected.ElementAt(i).Value);
                }
            }
        }
    }
}
