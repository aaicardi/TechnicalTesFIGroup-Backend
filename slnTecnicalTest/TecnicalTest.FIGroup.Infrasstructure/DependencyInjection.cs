﻿using Mapster;

using MapsterMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;
using TecnicalTest.FIGroup.Infrastructure.Persistence;

namespace TecnicalTest.FIGroup.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFacadeRepository, FacadeRepository>();
        //& serviceCollection.AddSingleton<IEmailService, EmailService>();
        serviceCollection.AddDbContext<FIGroupDBContext>(x =>
            x.UseSqlServer(
                Environment.GetEnvironmentVariable("FIGROUP_CONNECTION_STRING") ??
                string.Empty,
                o => o.UseNetTopologySuite()));
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        serviceCollection.AddSingleton(config);
        serviceCollection.AddScoped<IMapper, ServiceMapper>();
        return serviceCollection;
    }
}
