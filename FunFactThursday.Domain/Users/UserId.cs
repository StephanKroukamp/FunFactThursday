using FunFactThursday.Domain.common;

namespace FunFactThursday.Domain.Users;

public sealed record UserId(Guid Value) : IEntityId;