namespace HelloWorld.Test.Adriel;

using HelloWorld.Adriel;

public class HelloWorldTest
{
    [Fact]
    void ItShouldReturnHelloWorldToScreen()
    {
        Assert.Equal("Hello, Adriel!", new Hello().SayHello());
    }
}