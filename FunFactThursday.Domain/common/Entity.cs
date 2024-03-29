namespace FunFactThursday.Domain.common;

public abstract class Entity
{
    protected Entity(Guid id) : this()
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public Guid Id { get; set; }
}