using FunFactThursday.Domain.Tickets;
using Microsoft.EntityFrameworkCore;

namespace FunFactThursday.Persistence.Tickets;

internal sealed class TicketRepository : ITicketRepository
{
    private readonly FunFactThursdayDbContext _dbContext;

    public TicketRepository(FunFactThursdayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Ticket>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<Ticket>()
            .ToListAsync(cancellationToken);

    public async Task<Ticket?> GetByIdAsync(TicketId ticketId, CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<Ticket>()
            .FirstOrDefaultAsync(ticket => ticket.Id == ticketId, cancellationToken);

    public async Task<Ticket?> GetByTicketNumberAsync(string ticketNumber, CancellationToken cancellationToken = default) =>
        await _dbContext
            .Set<Ticket>()
            .FirstOrDefaultAsync(ticket => ticket.TicketNumber == ticketNumber, cancellationToken);
    public void Add(Ticket ticket)
    {
        _dbContext.Set<Ticket>().Add(ticket);
    }

    public void Remove(Ticket ticket)
    {
        _dbContext.Set<Ticket>().Remove(ticket);
    }
}