﻿using AbstractActionClass;
using ActionClass;

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
