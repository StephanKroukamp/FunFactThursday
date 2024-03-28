using FunFactThursday.Domain.common;
using FunFactThursday.Infrastructure;
using FunFactThursday.Persistence.common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FunFactThursday.Persistence;

public class FunFactThursdayDbContext : DbContext
{
    private readonly IPublisher _publisher;

    public FunFactThursdayDbContext(DbContextOptions<FunFactThursdayDbContext> options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Constants.Schemas.FunFactThursday);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.DetectChanges();

        var entries = ChangeTracker.Entries()
            .Where(t => t.State is EntityState.Added or EntityState.Modified)
            .Where(t => t.Entity is IAuditable)
            .ToArray();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property(nameof(IAuditable.CreatedOn)).CurrentValue = DateTimeOffset.Now;
                    break;
                case EntityState.Modified:
                    entry.Property(nameof(IAuditable.ModifiedOn)).CurrentValue = DateTimeOffset.Now;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        await PublishDomainEventsAsync();

        return result;
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<IEntity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }
}