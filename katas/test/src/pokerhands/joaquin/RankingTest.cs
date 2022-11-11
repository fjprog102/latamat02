namespace Ranking.Test.Joaquin;
using Ranking.Joaquin;

public class PokerRankingTest 
{

    [Fact]
    public void ItShouldReturnTheCardRanking()
    {
        Assert.Equal("high card", new PokerRanking().GetHandRanking("2C 3C 4S 8C KH"));  
        Assert.Equal("pair", new PokerRanking().GetHandRanking("2C 3H KS 8C KH"));  
        Assert.Equal("two pairs", new PokerRanking().GetHandRanking("3C 3H 7S 7C KH"));  
        Assert.Equal("three of a kind", new PokerRanking().GetHandRanking("3S 2H QS QC QH"));  
        Assert.Equal("straight", new PokerRanking().GetHandRanking("2C 3H 4C 5C 6H"));  
        Assert.Equal("flush", new PokerRanking().GetHandRanking("2C 3C 8C 5C QC"));  
        Assert.Equal("full house", new PokerRanking().GetHandRanking("2S 2C 8D 8S 8C"));  
        Assert.Equal("four of a kind", new PokerRanking().GetHandRanking("AS AC AD AH 8C"));
        Assert.Equal("straight flush", new PokerRanking().GetHandRanking("3D 4D 5D 6D 7D"));
    }

}