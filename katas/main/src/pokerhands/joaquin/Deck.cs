namespace PokerHands.Joaquin;

using System.Collections.Generic;

public class Deck
{
    public string[] cards = new string[52];

    public readonly char[] Suits = { 'C', 'D', 'H', 'S' };

    public readonly char[] CardValues = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

    public Dictionary<char, int> valuesRanking = new Dictionary<char, int>
    {
        {'2', 0},
        {'3', 1},
        {'4', 2},
        {'5', 3},
        {'6', 4},
        {'7', 5},
        {'8', 6},
        {'9', 7},
        {'T', 8},
        {'J', 9},
        {'Q', 10},
        {'K', 11},
        {'A', 12},
    };

    public Deck()
    {
        int index = 0;
        foreach (char suit in Suits)
        {
            foreach (char value in CardValues)
            {
                cards[index] = value.ToString() + suit.ToString();
                index++;
            }
        }
    }
}
