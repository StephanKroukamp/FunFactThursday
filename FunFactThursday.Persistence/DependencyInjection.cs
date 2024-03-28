﻿using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Registrations;
using FunFactThursday.Domain.Users;
using FunFactThursday.Persistence.common;
using FunFactThursday.Persistence.Registrations;
using FunFactThursday.Persistence.Users;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunFactThursday.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConnectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<RegistrationDbContext>(db => db.UseSqlServer(databaseConnectionString));
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddRepositories();
        
        services.AddMassTransitOutbox();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRegistrationRepository, RegistrationRepository>();
    }

    private static void AddMassTransitOutbox(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddEntityFrameworkOutbox<RegistrationDbContext>(o =>
            {
                o.QueryDelay = TimeSpan.FromSeconds(1);

                o.UseSqlServer();
                o.UseBusOutbox();
            });

            x.UsingRabbitMq((_, cfg) =>
            {
                cfg.AutoStart = true;
            });
        });
    }
}