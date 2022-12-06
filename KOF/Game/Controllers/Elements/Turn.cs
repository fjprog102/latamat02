namespace KOT.Controllers;

using KOT.Controllers.PlayerActions;
using KOT.Models;

public class Turn
{
    public KofDice Dices = new KofDice();
    public DiceAnalyzer Analyzer = new DiceAnalyzer();
    public StartTurn Start = new StartTurn();
    public EnterTokyo Move = new EnterTokyo();
    public BuyPowerCard BuyCard = new BuyPowerCard();
    public EndTurn End = new EndTurn();

    public void Play(GamePayload game, List<string> dices)
    {
        Start.Execute(dices, game);
        Analyzer.ResolveDice(dices, game);
        Move.Execute(dices, game);
        BuyCard.Execute(dices, game);
        End.Execute(dices, game);
    }
}
