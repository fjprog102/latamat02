using KOF.Models;

namespace KOF.Models.Test
{
    public class PlayerTest
    {
        private readonly Player player1 = new Player();

        [Fact]
        public void ShouldReturnPropertyId()
        {
            player1.PID = 1;
            Assert.Equal(1, player1.PID);

            Player player2 = new Player();
            player2.PID = 2;
            Assert.Equal(2, player2.PID);

            Player player3 = new Player();
            player3.PID = 3;
            Assert.Equal(3, player3.PID);
        }

        [Fact]
        public void ShouldReturnPropertyNameAsString()
        {
            player1.Name = "Pablo";
            Assert.Equal("Pablo", player1.Name);

            player1.Name = "Patrick";
            Assert.Equal("Patrick", player1.Name);

            player1.Name = "Bob";
            Assert.Equal("Bob", player1.Name);
        }

        [Fact]
        public void ShouldReturnMonsterAsObjectWhenMonsterIsDeclared()
        {
            player1.MyMonster = new Monster();
            Assert.False(object.ReferenceEquals(null, player1.MyMonster));
        }

        [Fact]
        public void ShouldReturnMonsterAsNullWhenMonsterIsNotDeclared()
        {
            Assert.True(object.ReferenceEquals(null, player1.MyMonster));
        }
    }
}
