using KOT.Services.Interfaces;

namespace KOT.Services.Injector;

public class ServiceInjector
{
    public ServiceInjector() { }

    public void InjectServices(IServiceCollection services)
    {
        //Add new services creating the respective interface
        services.AddSingleton<IDataService, PowerCardService>();
<<<<<<< HEAD
        services.AddSingleton<IGameService, GameService>();
=======
        services.AddSingleton<IMonsterService, MonsterService>();
>>>>>>> main
    }
}
