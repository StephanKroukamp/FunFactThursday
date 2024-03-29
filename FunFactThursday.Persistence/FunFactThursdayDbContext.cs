using FunFactThursday.Persistence.common;
using FunFactThursday.Persistence.StateMachines;
using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;

namespace FunFactThursday.Persistence;

public class FunFactThursdayDbContext : SagaDbContext
{
    public FunFactThursdayDbContext(DbContextOptions<FunFactThursdayDbContext> options) : base(options)
    {
    }

    protected override IEnumerable<ISagaClassMap> Configurations
    {
        get { yield return new RegistrationStateMap(); }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema(Constants.Schemas.FunFactThursday);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
        
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }
}