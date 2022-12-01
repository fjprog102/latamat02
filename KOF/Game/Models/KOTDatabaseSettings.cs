namespace KOT.Models;

public class KOTDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string PowerCardCollectionName { get; set; } = null!;
    public string GameCollectionName { get; set; } = null!;
}
