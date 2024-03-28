using FunFactThursday.Domain.common;

namespace FunFactThursday.Persistence.common;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly RegistrationDbContext _dbContext;

    public UnitOfWork(RegistrationDbContext dbContext) => _dbContext = dbContext;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.SaveChangesAsync(cancellationToken);
}