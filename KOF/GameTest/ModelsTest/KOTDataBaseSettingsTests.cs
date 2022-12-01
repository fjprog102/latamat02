using KOT.Models;

public class KOTDataBaseSettingsTests
{
    [Fact]
    public void TestKOTDataBaseAttributes()
    {
        KOTDatabaseSettings instance = new KOTDatabaseSettings();
        var attributes = instance.GetType().GetProperties();

        foreach (var attribute in attributes)
        {
            Assert.True(attribute.PropertyType == typeof(string));
        }
    }
}
