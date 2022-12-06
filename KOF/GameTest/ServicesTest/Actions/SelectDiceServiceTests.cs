using KOT.Models;
using KOT.Services;

public class SelectDiceServiceTests
{
    //
    [Fact]
    public void TestsSelectDicesSaveFirst3()
    {
        var choosenArray = new bool[] { true, true, true, false, false, false };
        var dicesInstance = new KofDice();
        var payloadInstance = new ChoosenDicePayload(choosen: choosenArray, dices: dicesInstance);
        var serviceInstance = new SelectDiceService();

        string[] current = new string[6];
        dicesInstance.BlackDices.CopyTo(current, 0);

        serviceInstance.SelectDices(payload: payloadInstance);

        for (int i = 0; i < 3; i++)
        {
            Assert.Equal(current.ElementAt(i), dicesInstance.BlackDices.ElementAt(i));
        }
    }

    [Fact]
    public void TestsSelectDicesSaveAll()
    {
        var choosenArray = new bool[] { true, true, true, true, true, true };
        var dicesInstance = new KofDice();
        var payloadInstance = new ChoosenDicePayload(choosen: choosenArray, dices: dicesInstance);
        var serviceInstance = new SelectDiceService();

        string[] current = new string[6];
        dicesInstance.BlackDices.CopyTo(current, 0);

        serviceInstance.SelectDices(payload: payloadInstance);

        for (int i = 0; i < current.Length; i++)
        {
            Assert.Equal(current.ElementAt(i), dicesInstance.BlackDices.ElementAt(i));
        }
    }
}
