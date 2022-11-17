using AbstractActionClass;
using ActionClass;

namespace ActionsTests
{
    public class MoveRightTest
    {
        [Fact]
        public void TestMoveRightIsChildInstance()
        {
            var instance = new MoveRight();
            Assert.True(
                instance.Instance.GetType().IsSubclassOf(typeof(AbstractAction<MoveRight>))
            );
        }
    }
}
