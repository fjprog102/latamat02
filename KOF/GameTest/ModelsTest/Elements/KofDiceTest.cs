namespace ModelsTests;

using KOT.Models;

public class KofDiceTest
{
    private readonly KofDice kofDice = new KofDice();

    [Fact]
    public void AKofDiceShouldHaveSixFaces()
    {
        Assert.Equal(6, kofDice.Faces.Count());
    }

    [Fact]
    public void AKofDiceFaceShouldHaveAValidSymbol()
    {
        foreach (string face in kofDice.Faces)
        {
            Assert.Contains(face, kofDice.Symbols);
        }
    }

    [Fact]
    public void ItShouldHaveSixBlackDicesWithSixFaces()
    {
        Assert.Equal(6, kofDice.BlackDices.Length);

        foreach (List<string> dice in kofDice.BlackDices)
        {
            Assert.Equal(dice, kofDice.Faces);
        }
    }

    [Fact]
    public void ItShouldHaveTwoGreenDicesWithSixFaces()
    {
        Assert.Equal(2, kofDice.GreenDices.Length);
        foreach (List<string> dice in kofDice.GreenDices)
        {
            Assert.Equal(dice, kofDice.Faces);
        }
    }

    [Fact]
    public void ItShouldRollDicesAndReturnAListWithSixRandomFaces()
    {
        var rolledDices = kofDice.RollDices(kofDice.BlackDices);
        Assert.IsType<List<string>>(rolledDices);

        foreach (string face in rolledDices)
        {
            Assert.Contains(face, kofDice.Symbols);
        }
    }
}
