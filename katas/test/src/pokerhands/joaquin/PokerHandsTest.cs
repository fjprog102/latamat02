namespace PokerHands.Test.Joaquin;
using Poker.Joaquin;


public class PokerHandsTest 
{

    [Fact]
    public void WhitePlayerShouldWin()
    {
        Assert.Equal("White wins. - with high card: Ace", new PokerClass().GetDealCardsResult("2H 3D 5S 9C KD", "2C 3H 4S 8C AH"));
    }

    [Fact]
    public void BlackPlayerShouldWin()
    {
        // POSSIBLE RANK CASES
        // High card
        Assert.Equal("Black wins. - with high card: 9", new PokerClass().GetDealCardsResult("2H 3D 5S 9C KD", "2C 3H 4S 8C KH")); 
        Assert.Equal("Black wins. - with high card: A", new PokerClass().GetDealCardsResult("AH KD QS JC TD", "9C TH JS QC KH")); 
        Assert.Equal("Black wins. - with high card: 4", new PokerClass().GetDealCardsResult("2H 2D 3S 3C 5D", "2C 3H 2S 3D 4H")); 
        Assert.Equal("Black wins. - with high card: A", new PokerClass().GetDealCardsResult("2H 3D 5S 5C AD", "2C 3H 5D 5H KH")); 
        // Pair
        Assert.Equal("Black wins. - with pair", new PokerClass().GetDealCardsResult("2H 3D 5S 5C KD", "2C 3H 4S 8C KH")); 
        Assert.Equal("Black wins. - with pair", new PokerClass().GetDealCardsResult("2H 3D 5S AC AD", "2C 3H KS 8C KH")); 
        Assert.Equal("Black wins. - with pair", new PokerClass().GetDealCardsResult("2H 3D 5S 3C 8D", "2C 2H TS 8C KH")); 
        // Two Pairs
        Assert.Equal("Black wins. - with two pairs", new PokerClass().GetDealCardsResult("3H 3D 5S 5C KD", "2C 3H 4S 8C KH")); 
        Assert.Equal("Black wins. - with two pairs", new PokerClass().GetDealCardsResult("2H 5D 5S AC AD", "2C 3H KS 8C KH")); 
        Assert.Equal("Black wins. - with two pairs", new PokerClass().GetDealCardsResult("2H 3D 5S 3C 8D", "2C 2H TS 8C KH")); 
        // Three
        Assert.Equal("Tie.", new PokerClass().GetDealCardsResult("4H 4D 5H 5D 8C", "5C 4C 4S 8S 5S"));
        // Straight
        Assert.Equal("Tie.", new PokerClass().GetDealCardsResult("6S 7C 8D 9D 10H", "6H 7S 8S 9S 10S"));
        // Flush

        // Full house
        Assert.Equal("Black wins. - with full house: 4 over 2", new PokerClass().GetDealCardsResult("2H 4S 4C 2D 4H", "2S 8S AS QS 3S"));
        // Four
        Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetDealCardsResult("7H 7S 7C 7D 4H", "2S 8S AS QS 3S"));
        Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetDealCardsResult("TH TS TC TD 4H", "9S 9S 9S 9S KS"));
        Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetDealCardsResult("8H 8S 8C 8D AH", "3S 4H 5C 6S 7S"));
        Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetDealCardsResult("2H 2S 2C 2D 2H", "KS KC JH JS KH"));
        Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetDealCardsResult("AH AS AC AD 10H", "JS 2C JH JS 8H"));
        Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetDealCardsResult("4H 4S 4C 4D 8H", "KS 2C 4H 2S KH"));
        Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetDealCardsResult("2H JS JC JD JH", "4S 5C 7H JS 7H"));
        // Straight flush
        Assert.Equal("Tie.", new PokerClass().GetDealCardsResult("8H 9H TH JH QH", "8C 9C TC JC QS"));
    }
    
    [Fact]
    public void ItShouldBeATie()
    {
        // C D H S
        // POSSIBLE RANK CASES
        // High card
        Assert.Equal("Tie.", new PokerClass().GetDealCardsResult("2H 3D 5S 9C KD", "2D 3H 5C 9S KH"));
        // Pair
        Assert.Equal("Tie.", new PokerClass().GetDealCardsResult("7D QH JC TS 7H", "7S QC JH TC 7C"));
        // Two Pairs
        Assert.Equal("Tie.", new PokerClass().GetDealCardsResult("4H 4D 5H 5D 8C", "5C 4C 4S 8S 5S"));
        // Straight
        Assert.Equal("Tie.", new PokerClass().GetDealCardsResult("6S 7C 8D 9D 10H", "6H 7S 8S 9S 10S"));
        // Straight flush
        Assert.Equal("Tie.", new PokerClass().GetDealCardsResult("8H 9H TH JH QH", "8C 9C TC JC QS"));
    }

    [Fact]
    public void ItShouldReturnSomeResult()
    {
        Assert.NotNull(new PokerClass().GetDealCardsResult("2H 3D 5S 9C KD", "2C 3H 4S 8C KH"));
    }

    public void ItShouldReturnAString()
    {
        Assert.True(new PokerClass().GetDealCardsResult("2H 3D 5S 9C KD", "2C 3H 4S 8C KH").GetType().Equals(typeof(string)));
    }

}