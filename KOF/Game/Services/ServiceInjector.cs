using KOT.Services.Interfaces;

namespace KOT.Services.Injector;

public class ServiceInjector
{
    public ServiceInjector() { }

    public void InjectServices(IServiceCollection services)
    {
        //Add new services creating the respective interface
        services.AddSingleton<IPlayerService, PlayerService>();
        services.AddSingleton<IGameService, GameService>();
        services.AddSingleton<IPowerCardService, PowerCardService>();
        services.AddSingleton<IMonsterService, MonsterService>();
        services.AddSingleton<IDatabaseService, DatabaseService>();
        services.AddSingleton<ISelectDiceService, SelectDiceService>();
    }
}
