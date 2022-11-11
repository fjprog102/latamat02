namespace PokerHand.Joaquin;

public class Hand
{

    public string value = ""; 
    public int amount = 1;

    public Hand()
    {

        while (amount < 6)
        {
            Card card = new Card();

            if(!this.value.Contains(card.value))
            {
                this.value += $"{card.value} ";
                amount += 1;
            }
        }

        this.value.Remove(value.Length - 1);
    }

}