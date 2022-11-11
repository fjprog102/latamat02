namespace Ranking.Joaquin;
using System;
using System.Collections.Generic;  

public class PokerRanking
{
    Dictionary<string, int> pokerRanking = new Dictionary<string, int>
    {
        {"high card", 0},
        {"pair", 1},
        {"two pairs", 2},
        {"three of a kind", 3},
        {"straight", 4},
        {"flush", 5},
        {"full house", 6},
        {"four of a kind", 7},
        {"straight flush", 8},
    };

    public string GetHandRanking(string hand)
    {
        // receive "2H 3D 5S 9C KD"
        return "ranking";
    }

}