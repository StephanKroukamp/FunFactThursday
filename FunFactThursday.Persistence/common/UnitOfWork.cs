using FunFactThursday.Domain.common;

namespace FunFactThursday.Persistence.common;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly FunFactThursdayDbContext _dbContext;

    public UnitOfWork(FunFactThursdayDbContext dbContext) => _dbContext = dbContext;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.SaveChangesAsync(cancellationToken);
}