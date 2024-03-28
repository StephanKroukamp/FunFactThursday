using FunFactThursday.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace FunFactThursday.Persistence.Users;

internal sealed class UserRepository : IUserRepository
{
    private readonly RegistrationDbContext _dbContext;

    public UserRepository(RegistrationDbContext dbContext) => _dbContext = dbContext;

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<User>()
            .ToListAsync(cancellationToken);

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<User>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<User>()
            .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default) =>
        !await _dbContext.Set<User>().AnyAsync(user => user.Email == email, cancellationToken);

    public void Add(User user) => 
        _dbContext.Set<User>().Add(user);

    public void Remove(User user) => 
        _dbContext.Set<User>().Remove(user);
}