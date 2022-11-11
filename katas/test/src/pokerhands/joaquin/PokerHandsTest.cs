namespace PokerHands.Test.Joaquin;
using Poker.Joaquin;

public class PokerHandsTest 
{

    // [Fact]
    // public void WhitePlayerShouldWin()
    // {
    //     // POSSIBLE RANK CASES
    //     // High card
    //     Assert.Equal("White wins. - with high card: 9", new PokerClass().GetHandWinner("2C 3H 4S 8C KH", "2H 3D 5S 9C KD")); 
    //     Assert.Equal("White wins. - with high card: A", new PokerClass().GetHandWinner("9C TH JS QC KH", "AH KD QS JC TD")); 
    //     Assert.Equal("White wins. - with high card: 5", new PokerClass().GetHandWinner("2C 3H 2S 3D 4H", "2H 2D 3S 3C 5D")); 
    //     Assert.Equal("White wins. - with high card: A", new PokerClass().GetHandWinner("2C 3H 5D 5H KH", "2H 3D 5S 5C AD")); 
    //     // Pair
    //     Assert.Equal("White wins. - with pair", new PokerClass().GetHandWinner("2C 3H 4S 8C KH", "2H 3D 5S 5C KD")); 
    //     Assert.Equal("White wins. - with pair", new PokerClass().GetHandWinner("2C 3H KS 8C KH", "2H 3D 5S AC AD")); 
    //     Assert.Equal("White wins. - with pair", new PokerClass().GetHandWinner("2C 2H TS 8C KH", "2H 3D 5S 3C 8D")); 
    //     // Two Pairs
    //     Assert.Equal("White wins. - with two pairs", new PokerClass().GetHandWinner("2C 3H 4S 8C KH", "3H 3D 5S 5C KD")); 
    //     Assert.Equal("White wins. - with two pairs", new PokerClass().GetHandWinner("2C 3H KS 8C KH", "2H 5D 5S AC AD")); 
    //     Assert.Equal("White wins. - with two pairs", new PokerClass().GetHandWinner("3C 3H 7S 7C KH", "2H 3D 8S 3C 8D")); 
    //     Assert.Equal("White wins. - with two pairs", new PokerClass().GetHandWinner("3C 3H 7S QC QH", "2H 6D QS 6C QD")); 
    //     // Three
    //     Assert.Equal("White wins. - with three of a kind", new PokerClass().GetHandWinner("2C 3H 4S 8C KH", "3H 5D 5S 5C KD")); 
    //     Assert.Equal("White wins. - with three of a kind", new PokerClass().GetHandWinner("2C 3H KS 8C KH", "2H 2D 2S 5C AD"));  
    //     Assert.Equal("White wins. - with three of a kind", new PokerClass().GetHandWinner("3C 3H 7S 7C KH", "8H 6D 8S 3C 8D")); 
    //     Assert.Equal("White wins. - with three of a kind", new PokerClass().GetHandWinner("3C 3H QS QC QH", "AH 6D AS AC QD"));  
    //     // Straight
    //     Assert.Equal("White wins. - with straight", new PokerClass().GetHandWinner("2C 3H 4S 8C KH", "1H 2D 3S 4C 5D")); 
    //     Assert.Equal("White wins. - with straight", new PokerClass().GetHandWinner("2C 3H KS 8C KH", "7H 8D 9S 6C 5D")); 
    //     Assert.Equal("White wins. - with straight", new PokerClass().GetHandWinner("3C 3H 7S 7C KH", "TH 9D JS QC KD"));  
    //     Assert.Equal("White wins. - with straight", new PokerClass().GetHandWinner("3C 3H QS JC QH", "3H 6D 4S 5C 2D")); 
    //     Assert.Equal("White wins. - with straight", new PokerClass().GetHandWinner("2C 3H 4S 5C 6H", "4H 5D 6S 7C 8D")); 
    //     // Flush
    //     Assert.Equal("White wins. - with flush", new PokerClass().GetHandWinner("2C 3C 4S 8C KH", "1H 2H 3H 8H QH"));  
    //     Assert.Equal("White wins. - with flush", new PokerClass().GetHandWinner("2C 3H KS 8C KH", "7D 8D 9D KD 2D")); 
    //     Assert.Equal("White wins. - with flush", new PokerClass().GetHandWinner("3C 3H 7S 7C KH", "TS 5S JS QS 4S"));  
    //     Assert.Equal("White wins. - with flush", new PokerClass().GetHandWinner("3S 3H JS QC QH", "3C JC 4C KC 2C")); 
    //     Assert.Equal("White wins. - with flush", new PokerClass().GetHandWinner("2C 3H 4C 5C 6H", "4S 5S 6S TS 2S")); 
    //     Assert.Equal("White wins. - with flush", new PokerClass().GetHandWinner("2C 3C 8C 5C QC", "4S 5S 6S TS AS")); 
    //     Assert.Equal("White wins. - with flush", new PokerClass().GetHandWinner("2S 3S 8S 9S JS", "4S 5S 6S TS KS")); 
    //     // Full house
    //     Assert.Equal("White wins. - with full house: 3 over 2", new PokerClass().GetHandWinner("2C 3C 4S 8C KH", "2D 2H 2S 3D 3S")); 
    //     Assert.Equal("White wins. - with full house: T over 4", new PokerClass().GetHandWinner("2C 3H KS 8C KH", "TC TS TH 4D 4S")); 
    //     Assert.Equal("White wins. - with full house: 8 over 7", new PokerClass().GetHandWinner("3C 3H 7S 7C KH", "8S 8C 8D 7D 7H"));  
    //     Assert.Equal("White wins. - with full house: Q over 3", new PokerClass().GetHandWinner("3S 2H JS JS JH", "QC 3D 3C QH QD")); 
    //     Assert.Equal("White wins. - with full house: 7 over 5", new PokerClass().GetHandWinner("2C 3H 4C 5C 6H", "5S 5H 7S 5D 7C")); 
    //     Assert.Equal("White wins. - with full house: K over T", new PokerClass().GetHandWinner("2C 3C 8C 5C QC", "KS TS KH TH KC"));  
    //     Assert.Equal("White wins. - with full house: A over 9", new PokerClass().GetHandWinner("2S 2C 8D 8S 8C", "AS 9S 9H AC AD")); 
    //     // Four
    //     Assert.Equal("White wins. - with four of a kind", new PokerClass().GetHandWinner("2S 8S AS QS 3S", "7H 7S 7C 7D 4H"));
    //     Assert.Equal("White wins. - with four of a kind", new PokerClass().GetHandWinner("9S 9S 9S 9S KS", "TH TS TC TD 4H"));
    //     Assert.Equal("White wins. - with four of a kind", new PokerClass().GetHandWinner("3S 4H 5C 6S 7S", "8H 8S 8C 8D AH"));
    //     Assert.Equal("White wins. - with four of a kind", new PokerClass().GetHandWinner("KS KC JH JS KH", "2H 2S 2C 2D 2H"));
    //     Assert.Equal("White wins. - with four of a kind", new PokerClass().GetHandWinner("JS 2C JH JS 8H", "AH AS AC AD 10H"));
    //     Assert.Equal("White wins. - with four of a kind", new PokerClass().GetHandWinner("KS 2C 4H 2S KH", "4H 4S 4C 4D 8H"));
    //     Assert.Equal("White wins. - with four of a kind", new PokerClass().GetHandWinner("4S 5C 7H JS 7H", "2H JS JC JD JH"));
    //     // Straight flush
    //     Assert.Equal("White wins. - with straight flush", new PokerClass().GetHandWinner("2C 3C 4S 8C KH", "6H 2H 3H 4H 5H"));  
    //     Assert.Equal("White wins. - with straight flush", new PokerClass().GetHandWinner("2C 3H KS 8C KH", "7D 8D 9D 6D 5D"));  
    //     Assert.Equal("White wins. - with straight flush", new PokerClass().GetHandWinner("3C 3H 7S 7C KH", "TS 9S JS QS KS"));  
    //     Assert.Equal("White wins. - with straight flush", new PokerClass().GetHandWinner("3S 3H JS QC QH", "3C 6C 4C 5C 2C"));  
    //     Assert.Equal("White wins. - with straight flush", new PokerClass().GetHandWinner("2C 3H 4C 5C 6H", "4S 5S 6S 7S 8S"));  
    //     Assert.Equal("White wins. - with straight flush", new PokerClass().GetHandWinner("2C 3C 8C 5C QC", "KS TS JS QS 9S"));  
    //     Assert.Equal("White wins. - with straight flush", new PokerClass().GetHandWinner("2S 2C 8D 8S 8C", "5H 9H 6H 7H 8H"));  
    //     Assert.Equal("White wins. - with straight flush", new PokerClass().GetHandWinner("AS AC AD AH 8C", "8S 9S 6S 7S TS"));
    // }

    // [Fact]
    // public void BlackPlayerShouldWin()
    // {
    //     // POSSIBLE RANK CASES
    //     // High card
    //     Assert.Equal("Black wins. - with high card: 9", new PokerClass().GetHandWinner("2H 3D 5S 9C KD", "2C 3H 4S 8C KH")); 
    //     Assert.Equal("Black wins. - with high card: A", new PokerClass().GetHandWinner("AH KD QS JC TD", "9C TH JS QC KH")); 
    //     Assert.Equal("Black wins. - with high card: 4", new PokerClass().GetHandWinner("2H 2D 3S 3C 5D", "2C 3H 2S 3D 4H")); 
    //     Assert.Equal("Black wins. - with high card: A", new PokerClass().GetHandWinner("2H 3D 5S 5C AD", "2C 3H 5D 5H KH")); 
    //     // Pair
    //     Assert.Equal("Black wins. - with pair", new PokerClass().GetHandWinner("2H 3D 5S 5C KD", "2C 3H 4S 8C KH")); 
    //     Assert.Equal("Black wins. - with pair", new PokerClass().GetHandWinner("2H 3D 5S AC AD", "2C 3H KS 8C KH")); 
    //     Assert.Equal("Black wins. - with pair", new PokerClass().GetHandWinner("2H 3D 5S 3C 8D", "2C 2H TS 8C KH")); 
    //     // Two Pairs
    //     Assert.Equal("Black wins. - with two pairs", new PokerClass().GetHandWinner("3H 3D 5S 5C KD", "2C 3H 4S 8C KH")); 
    //     Assert.Equal("Black wins. - with two pairs", new PokerClass().GetHandWinner("2H 5D 5S AC AD", "2C 3H KS 8C KH")); 
    //     Assert.Equal("Black wins. - with two pairs", new PokerClass().GetHandWinner("2H 3D 8S 3C 8D", "3C 3H 7S 7C KH")); 
    //     Assert.Equal("Black wins. - with two pairs", new PokerClass().GetHandWinner("2H 6D QS 6C QD", "3C 3H 7S QC QH")); 
    //     // Three
    //     Assert.Equal("Black wins. - with three of a kind", new PokerClass().GetHandWinner("3H 5D 5S 5C KD", "2C 3H 4S 8C KH")); 
    //     Assert.Equal("Black wins. - with three of a kind", new PokerClass().GetHandWinner("2H 2D 2S 5C AD", "2C 3H KS 8C KH")); 
    //     Assert.Equal("Black wins. - with three of a kind", new PokerClass().GetHandWinner("8H 6D 8S 3C 8D", "3C 3H 7S 7C KH")); 
    //     Assert.Equal("Black wins. - with three of a kind", new PokerClass().GetHandWinner("AH 6D AS AC QD", "3C 3H QS QC QH")); 
    //     // Straight
    //     Assert.Equal("Black wins. - with straight", new PokerClass().GetHandWinner("1H 2D 3S 4C 5D", "2C 3H 4S 8C KH")); 
    //     Assert.Equal("Black wins. - with straight", new PokerClass().GetHandWinner("7H 8D 9S 6C 5D", "2C 3H KS 8C KH")); 
    //     Assert.Equal("Black wins. - with straight", new PokerClass().GetHandWinner("TH 9D JS QC KD", "3C 3H 7S 7C KH")); 
    //     Assert.Equal("Black wins. - with straight", new PokerClass().GetHandWinner("3H 6D 4S 5C 2D", "3C 3H QS JC QH")); 
    //     Assert.Equal("Black wins. - with straight", new PokerClass().GetHandWinner("4H 5D 6S 7C 8D", "2C 3H 4S 5C 6H")); 
    //     // Flush
    //     Assert.Equal("Black wins. - with flush", new PokerClass().GetHandWinner("1H 2H 3H 8H QH", "2C 3C 4S 8C KH")); 
    //     Assert.Equal("Black wins. - with flush", new PokerClass().GetHandWinner("7D 8D 9D KD 2D", "2C 3H KS 8C KH")); 
    //     Assert.Equal("Black wins. - with flush", new PokerClass().GetHandWinner("TS 5S JS QS 4S", "3C 3H 7S 7C KH")); 
    //     Assert.Equal("Black wins. - with flush", new PokerClass().GetHandWinner("3C JC 4C KC 2C", "3S 3H JS QC QH")); 
    //     Assert.Equal("Black wins. - with flush", new PokerClass().GetHandWinner("4S 5S 6S TS 2S", "2C 3H 4C 5C 6H")); 
    //     Assert.Equal("Black wins. - with flush", new PokerClass().GetHandWinner("4S 5S 6S TS AS", "2C 3C 8C 5C QC")); 
    //     Assert.Equal("Black wins. - with flush", new PokerClass().GetHandWinner("4S 5S 6S TS KS", "2S 3S 8S 9S JS")); 
    //     // Full house
    //     Assert.Equal("Black wins. - with full house: 3 over 2", new PokerClass().GetHandWinner("2D 2H 2S 3D 3S", "2C 3C 4S 8C KH")); 
    //     Assert.Equal("Black wins. - with full house: T over 4", new PokerClass().GetHandWinner("TC TS TH 4D 4S", "2C 3H KS 8C KH")); 
    //     Assert.Equal("Black wins. - with full house: 8 over 7", new PokerClass().GetHandWinner("8S 8C 8D 7D 7H", "3C 3H 7S 7C KH")); 
    //     Assert.Equal("Black wins. - with full house: Q over 3", new PokerClass().GetHandWinner("QC 3D 3C QH QD", "3S 2H JS JS JH")); 
    //     Assert.Equal("Black wins. - with full house: 7 over 5", new PokerClass().GetHandWinner("5S 5H 7S 5D 7C", "2C 3H 4C 5C 6H")); 
    //     Assert.Equal("Black wins. - with full house: K over T", new PokerClass().GetHandWinner("KS TS KH TH KC", "2C 3C 8C 5C QC")); 
    //     Assert.Equal("Black wins. - with full house: A over 9", new PokerClass().GetHandWinner("AS 9S 9H AC AD", "2S 2C 8D 8S 8C")); 
    //     // Four
    //     Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetHandWinner("7H 7S 7C 7D 4H", "2S 8S AS QS 3S"));
    //     Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetHandWinner("TH TS TC TD 4H", "9S 9S 9S 9S KS"));
    //     Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetHandWinner("8H 8S 8C 8D AH", "3S 4H 5C 6S 7S"));
    //     Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetHandWinner("2H 2S 2C 2D 2H", "KS KC JH JS KH"));
    //     Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetHandWinner("AH AS AC AD 10H", "JS 2C JH JS 8H"));
    //     Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetHandWinner("4H 4S 4C 4D 8H", "KS 2C 4H 2S KH"));
    //     Assert.Equal("Black wins. - with four of a kind", new PokerClass().GetHandWinner("2H JS JC JD JH", "4S 5C 7H JS 7H"));
    //     // Straight flush
    //     Assert.Equal("Black wins. - with straight flush", new PokerClass().GetHandWinner("6H 2H 3H 4H 5H", "2C 3C 4S 8C KH")); 
    //     Assert.Equal("Black wins. - with straight flush", new PokerClass().GetHandWinner("7D 8D 9D 6D 5D", "2C 3H KS 8C KH")); 
    //     Assert.Equal("Black wins. - with straight flush", new PokerClass().GetHandWinner("TS 9S JS QS KS", "3C 3H 7S 7C KH")); 
    //     Assert.Equal("Black wins. - with straight flush", new PokerClass().GetHandWinner("3C 6C 4C 5C 2C", "3S 3H JS QC QH")); 
    //     Assert.Equal("Black wins. - with straight flush", new PokerClass().GetHandWinner("4S 5S 6S 7S 8S", "2C 3H 4C 5C 6H")); 
    //     Assert.Equal("Black wins. - with straight flush", new PokerClass().GetHandWinner("KS TS JS QS 9S", "2C 3C 8C 5C QC")); 
    //     Assert.Equal("Black wins. - with straight flush", new PokerClass().GetHandWinner("5H 9H 6H 7H 8H", "2S 2C 8D 8S 8C")); 
    //     Assert.Equal("Black wins. - with straight flush", new PokerClass().GetHandWinner("8S 9S 6S 7S TS", "AS AC AD AH 8C")); 
    // }
    
    // [Fact]
    // public void ItShouldBeATie()
    // {
    //     // POSSIBLE RANK CASES
    //     // High card
    //     Assert.Equal("Tie.", new PokerClass().GetHandWinner("2H 3D 5S 9C KD", "2D 3H 5C 9S KH"));
    //     Assert.Equal("Tie.", new PokerClass().GetHandWinner("AH QD 5S 9C KD", "AD QH 5C 9S KH"));
    //     // Pair
    //     Assert.Equal("Tie.", new PokerClass().GetHandWinner("7D QH JC TS 7H", "7S QC JH TC 7C"));
    //     Assert.Equal("Tie.", new PokerClass().GetHandWinner("AD QH JC AS 7H", "3S AC AH TC 7C"));
    //     Assert.Equal("Tie.", new PokerClass().GetHandWinner("QD 3H JC QS 7H", "7S QC QH TC 7C"));
    //     // Two Pairs
    //     Assert.Equal("Tie.", new PokerClass().GetHandWinner("4H 4D 5H 5D 8C", "5C 4C 4S 8S 5S"));
    //     // Straight
    //     Assert.Equal("Tie.", new PokerClass().GetHandWinner("6S 7C 8D 9D 10H", "6H 7S 8S 9S 10S"));
    //     // Straight flush
    //     Assert.Equal("Tie.", new PokerClass().GetHandWinner("8H 9H TH JH QH", "8C 9C TC JC QS"));
    // }

    // [Fact]
    // public void ItShouldReturnAString()
    // {
    //     Assert.NotNull(new PokerClass().GetHandWinner("2H 3D 5S 9C KD", "2C 3H 4S 8C KH"));
    //     Assert.True(new PokerClass().GetHandWinner("2H 3D 5S 9C KD", "2C 3H 4S 8C KH").GetType().Equals(typeof(string)));
    // }


}