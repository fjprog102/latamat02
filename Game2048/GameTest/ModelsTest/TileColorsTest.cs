namespace ModelsTests;

using System.Text.RegularExpressions;
using Models;

public class TileColorsTest
{
    [Fact]
    public void BackgroundColorPropertyShouldHaveARandomColorString()
    {
        Assert.Matches("^#[\\w]{6}$", new TileColors().GetBackgroundColor(2));
        Assert.Matches("^#[\\w]{6}$", new TileColors().GetBackgroundColor(4));
        Assert.Matches("^#[\\w]{6}$", new TileColors().GetBackgroundColor(8));
        Assert.Matches("^#[\\w]{6}$", new TileColors().GetBackgroundColor(16));
        Assert.Matches("^#[\\w]{6}$", new TileColors().GetBackgroundColor(32));
    }

    [Fact]
    public void NumberColorPropertyShouldHaveABlackOrWhiteColorString()
    {
        Assert.Matches("#[fff|000]", new TileColors().GetNumberColor(2));
        Assert.Matches("#[fff|000]", new TileColors().GetNumberColor(4));
        Assert.Matches("#[fff|000]", new TileColors().GetNumberColor(6));
        Assert.Matches("#[fff|000]", new TileColors().GetNumberColor(8));
    }
}
