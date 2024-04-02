using FunFactThursday.Persistence.common;
using Microsoft.EntityFrameworkCore;

namespace FunFactThursday.Persistence;

public class FunFactThursdayDbContext : DbContext
{
    public FunFactThursdayDbContext(DbContextOptions<FunFactThursdayDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(Constants.Schemas.FunFactThursday);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }
}