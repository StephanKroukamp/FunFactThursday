using FunFactThursday.Application.Users.Consumers;
using FunFactThursday.Persistence;
using FunFactThursday.Persistence.Consumers;
using FunFactThursday.Persistence.StateMachines;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<RegistrationDbContext>(x =>
        {
            var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");

            x.UseSqlServer(connectionString, options =>
            {
                options.MinBatchSize(1);
            });
        });
        
        services.AddScoped<IRegistrationValidationService, RegistrationValidationService>();
        
        services.AddMassTransit(x =>
        {
            x.AddEntityFrameworkOutbox<RegistrationDbContext>(o =>
            {
                o.UseSqlServer();

                o.DuplicateDetectionWindow = TimeSpan.FromSeconds(30);
            });

            x.SetKebabCaseEndpointNameFormatter();

            x.AddConsumer<NotifyRegistrationConsumer>();
            x.AddConsumer<SendRegistrationEmailConsumer>();
            x.AddConsumer<AddEventAttendeeConsumer>();
            x.AddConsumer<ValidateRegistrationConsumer, ValidateRegistrationConsumerDefinition>();
            x.AddSagaStateMachine<RegistrationStateMachine, RegistrationState, RegistrationStateDefinition>()
                .EntityFrameworkRepository(r =>
                {
                    r.ExistingDbContext<RegistrationDbContext>();
                    r.UseSqlServer();
                });

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });
    })
    .Build();

await host.RunAsync();