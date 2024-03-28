namespace FunFactThursday.Domain.Tickets;

public interface ITicketRepository
{
    Task<List<Ticket>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Ticket?> GetByIdAsync(TicketId ticketId, CancellationToken cancellationToken = default);
    
    Task<Ticket?> GetByTicketNumberAsync(string ticketNumber, CancellationToken cancellationToken = default);

    void Add(Ticket ticket);

    void Remove(Ticket ticket);
}