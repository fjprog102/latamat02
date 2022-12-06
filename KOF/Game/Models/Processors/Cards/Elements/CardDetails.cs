namespace KOT.Models.Processor;

public class CardDetails
{
    public Effect effect;
    public PowerCard powerCard;

    public CardDetails(PowerCard powerCard, Effect effect)
    {
        this.powerCard = powerCard;
        this.effect = effect;
    }
}
