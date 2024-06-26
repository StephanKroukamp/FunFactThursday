﻿using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Events;
using FunFactThursday.Domain.Registrations;
using FunFactThursday.Domain.Users;
using FunFactThursday.Persistence.common;
using FunFactThursday.Persistence.Events;
using FunFactThursday.Persistence.Registrations;
using FunFactThursday.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunFactThursday.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConnectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<FunFactThursdayDbContext>(db => db.UseSqlServer(databaseConnectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRegistrationRepository, RegistrationRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
    }
}