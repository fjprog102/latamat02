using Actions;
using Actions.Movements;

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
    }
}
