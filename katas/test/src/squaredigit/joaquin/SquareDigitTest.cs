using SquareDigit.Joaquin;

namespace SquareDigit.Test.Joaquin {
    public class SquareDigitTest {
        
        [Fact]
        public void ItShouldReturnAllDigitsToSquare()
        {
            Assert.Equal(0, new SquareDigitClass().squareDigits(0));
            Assert.Equal(1, new SquareDigitClass().squareDigits(1));
            Assert.Equal(25, new SquareDigitClass().squareDigits(5));
            Assert.Equal(4949, new SquareDigitClass().squareDigits(77));
            Assert.Equal(811181, new SquareDigitClass().squareDigits(9119));
        }

         [Fact]
         public void ItShouldReturnAnInteger(){
             Assert.Equal(true, new SquareDigitClass().squareDigits(9119).GetType().Equals(typeof(int)));
         }
        
    }
}