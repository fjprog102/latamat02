using AbstractActionClass;
using ActionClass;

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
    }
}
