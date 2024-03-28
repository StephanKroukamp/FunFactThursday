using FunFactThursday.Domain.common;

namespace FunFactThursday.Domain.Tickets;

public sealed record TicketId(Guid Value) : IEntityId;