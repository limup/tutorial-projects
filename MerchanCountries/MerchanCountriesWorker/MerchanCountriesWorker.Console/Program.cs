using System.Security.AccessControl;
using MerchanCountriesWorker.Console;
using MerchanCountriesWorker.Console.Repositories;
using MerchanCountriesWorker.Core.Models;
using MerchanCountriesWorker.Data.Context;
using MerchanCountriesWorker.Data.Repositories;
using MerchanCountriesWorker.Data.Repositories.Abstractions;
using MerchanCountriesWorker.Domain;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<ScopedBackgroundService>();
        services.Configure<MongoSettings>(context.Configuration.GetSection("MongoSettings"));

        services.AddScoped<IScopedProcessingService, DefaultScopedProcessingService>();
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IMongoDBContext, MongoDBContext>();
        services.AddScoped<ICountryRepository, CountryRepository>();
    })
    .Build();

host.Run();
