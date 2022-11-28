﻿using KOT.Services.Injector;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Builder;

public class InjectorTests
{
    [Fact]
    public void TestInjectorForPowerCardService()
    {
        var builder = WebApplication.CreateBuilder();

        var serviceInjector = new ServiceInjector();
        serviceInjector.InjectServices(builder.Services);

        var serviceMatches = builder.Services
            .Select(service => service)
            .Where(service => service.ServiceType == typeof(IDataService));

        Assert.Equal(1, serviceMatches.Count());
    }
}
