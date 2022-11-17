using AbstractActionClass;
using ActionClass;

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
    }
}
