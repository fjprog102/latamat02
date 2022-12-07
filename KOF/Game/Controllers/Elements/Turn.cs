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
    public EliminatePlayer Eliminate = new EliminatePlayer();
    public CheckWinner CheckWinner = new CheckWinner();

    public void Play(GamePayload game, string[] dices)
    {
        Start.Execute(dices, game);
        // Dices.GenerateKofDices(
        //     Dices.BlackDices,
        //     new bool[] { true, false, true, false, true, false }
        // );
        Analyzer.ResolveDice(dices, game);
        Eliminate.Execute(dices, game);
        Move.Execute(dices, game);
        BuyCard.Execute(dices, game);
        End.Execute(dices, game);
        CheckWinner.Execute(dices, game);
    }
}
