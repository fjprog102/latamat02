using HelloWorld.Valeria;
namespace HelloWorld.Test.Valeria
{
    public class HelloWorldTest
    {
        [Fact]
        private void ItShouldSayHelloValeria()
        {
            Assert.Equal("Hello, Valeria!", new Hello().SayHello());
        }
    }
}
