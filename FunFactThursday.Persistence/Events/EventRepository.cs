using FunFactThursday.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace FunFactThursday.Persistence.Events;

public class EventRepository : IEventRepository
{
    private readonly FunFactThursdayDbContext _dbContext;

    public EventRepository(FunFactThursdayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Event>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<Event>()
            .ToListAsync(cancellationToken);

    public async Task<Event?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<Event>()
            .FirstOrDefaultAsync(registration => registration.Id == id, cancellationToken);

    public async Task<Event?> GetByNameAsync(string name, CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<Event>()
            .FirstOrDefaultAsync(@event => @event.Name == name, cancellationToken);

    public async Task<bool> IsNameUniqueAsync(string name, CancellationToken cancellationToken = default) =>
        !await _dbContext.Set<Event>().AnyAsync(@event => @event.Name == name, cancellationToken);

    public void Add(Event @event)
    {
        _dbContext.Set<Event>().Add(@event);
    }

    public void Remove(Event @event)
    {
        _dbContext.Set<Event>().Remove(@event);
    }
}