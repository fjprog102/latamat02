namespace PokerHands.Hands.Test.Adriel;

using Cards.Adriel;
using Enums.Adriel;
using Hands.Adriel;

public class HandTest
{
    [Fact]
    private void ShouldReturnAnArgumentExceptionForInvalidHandInput()
    {
        string message = "Hand must contain 5 cards";

        ArgumentException ex = Assert.Throws<ArgumentException>(() => new Hand("2c 3d 4h 5c"));
        Assert.Equal(message, ex.Message);

        ArgumentException ex2 = Assert.Throws<ArgumentException>(() => new Hand("2c 3d "));
        Assert.Equal(message, ex2.Message);

        ArgumentException ex3 = Assert.Throws<ArgumentException>(() => new Hand(""));
        Assert.Equal(message, ex3.Message);

        ArgumentException ex4 = Assert.Throws<ArgumentException>(() => new Hand("2c 3d 4h 5c ac 7d"));
        Assert.Equal(message, ex4.Message);
    }

    [Fact]
    private void MethodShouldCorrectlyReturnIfAHandContainsACardForPassedValue()
    {
        Hand hand = new Hand("as 2s 3s 4s 5s");

        Assert.True(hand.Contains(Value.Ace));
        Assert.True(hand.Contains(Value.Three));
        Assert.True(hand.Contains(Value.Two));
        Assert.True(hand.Contains(Value.Five));
    }

    [Fact]
    private void MethodShouldCorrectlyReturnIfAHandDoesntContainsACardForPassedValue()
    {
        Hand hand = new Hand("2s 4s 6s 8s ks");

        Assert.False(hand.Contains(Value.Ace));
        Assert.False(hand.Contains(Value.Ten));
        Assert.False(hand.Contains(Value.Jack));
        Assert.False(hand.Contains(Value.Queen));
    }

    [Fact]
    private void ShouldAssertThatCardsAreCreatedAsAList()
    {
        Hand hand = new Hand("2s 4s 6s 8s ks");
        Assert.IsType<List<Card>>(hand.Cards);
    }

    [Fact]
    private void MethodShouldCorrectlyReturnAHandCreatedAsAString()
    {
        Hand hand = new Hand("8s 4s 7s 8d ks");
        Assert.Equal("8s 4s 7s 8d Ks", hand.ToString());

        Hand hand2 = new Hand("ac 5s 8d ks Qc");
        Assert.Equal("Ac 5s 8d Ks Qc", hand2.ToString());

        Hand hand3 = new Hand("7h 7d 2s 3d ac");
        Assert.Equal("7h 7d 2s 3d Ac", hand3.ToString());
    }
}
