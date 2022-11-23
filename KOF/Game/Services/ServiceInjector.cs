using KOF.Services.Interfaces;

namespace KOF.Services.Injector;

public class ServiceInjector
{
    public ServiceInjector() { }

    public void InjectServices(IServiceCollection services)
    {
        //Add new services creating the respective interface
        services.AddSingleton<IPowerCard, PowerCardService>();
    }
}
