using KOF.Models;

namespace KOF.Models.Test
{
    public class PlayerTest
    {
        private readonly Player player1 = new Player();

        [Fact]
        public void ShouldReturnPropertyId()
        {
            player1.PID = "XslT@dfQ5F";
            Assert.Equal("XslT@dfQ5F", player1.PID);

            Player player2 = new Player();
            player2.PID = "AgSD$Fgkdf";
            Assert.Equal("AgSD$Fgkdf", player2.PID);

            Player player3 = new Player();
            player3.PID = "5Fdf9&plGx";
            Assert.Equal("5Fdf9&plGx", player3.PID);
        }

        [Fact]
        public void ShouldReturnPropertyNameAsString()
        {
            player1.DisplayName = "Pablo";
            Assert.Equal("Pablo", player1.DisplayName);

            player1.DisplayName = "Patrick";
            Assert.Equal("Patrick", player1.DisplayName);

            player1.DisplayName = "Bob";
            Assert.Equal("Bob", player1.DisplayName);
        }

        [Fact]
        public void ShouldReturnEmailAsString()
        {
            player1.Email = "pablo@gmail.com";
            Assert.Equal("pablo@gmail.com", player1.Email);

            player1.Email = "patrick@gmail.com";
            Assert.Equal("patrick@gmail.com", player1.Email);

            player1.Email = "bob123@gmail.com";
            Assert.Equal("bob123@gmail.com", player1.Email);
        }

        [Fact]
        public void ShouldReturnPropertyPhotoIdAsString()
        {
            player1.PID = "asDFx#1tRm";
            Assert.Equal("asDFx#1tRm", player1.PID);

            Player player2 = new Player();
            player2.PID = "Ap5dgOmNi$";
            Assert.Equal("Ap5dgOmNi$", player2.PID);

            Player player3 = new Player();
            player3.PID = "&3$fPxX12V";
            Assert.Equal("&3$fPxX12V", player3.PID);
        }

        [Fact]
        public void ShouldReturnPropertyIsPaidUserAsBool()
        {
            player1.IsPaidUser = false;
            Assert.False(player1.IsPaidUser);

            player1.IsPaidUser = true;
            Assert.True(player1.IsPaidUser);
        }
    }
}
