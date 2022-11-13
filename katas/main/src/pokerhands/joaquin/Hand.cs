namespace PokerHand.Joaquin;

public class Hand
{

    public string[] cards = new string[5]; 
    // public int amount = 0;

    Card Card = new Card();

    public Hand()
    {

        // while (amount < 5)
        // {
        //     int index = 0;
        //     string card = Card.CreateCard();

        //     if(!cards.Contains(card))
        //     {
        //         cards[0] += card;
        //         index += 1;
        //     }
        // }


        for (int i = 0; i < cards.Length; i++)
        {
            string card = Card.CreateCard();

            if(!cards.Contains(card))
            {
                cards[i] += card;
            }
            else {
                i--;
            }
        }        
    }

}