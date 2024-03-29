using FunFactThursday.Domain.Registrations;
using Microsoft.EntityFrameworkCore;

namespace FunFactThursday.Persistence.Registrations;

public class RegistrationRepository : IRegistrationRepository
{
    private readonly FunFactThursdayDbContext _dbContext;

    public RegistrationRepository(FunFactThursdayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Registration>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<Registration>()
            .ToListAsync(cancellationToken);

    public async Task<Registration?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<Registration>()
            .FirstOrDefaultAsync(registration => registration.Id == id, cancellationToken);

    public void Add(Registration registration)
    {
        _dbContext.Set<Registration>().Add(registration);
    }

    public void Remove(Registration registration)
    {
        _dbContext.Set<Registration>().Remove(registration);
    }
}