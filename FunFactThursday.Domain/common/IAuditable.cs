namespace FunFactThursday.Domain.common;

public interface IAuditable
{
    DateTimeOffset CreatedOn { get; }

    DateTimeOffset? ModifiedOn { get; }
}