namespace Modular.Monolithic.Architecture.Helper.Domain.Events;

public class DomainEvent : IDomainEvent
{
    public Guid Id { get; }
    public DateTime OccurredOn { get; }

    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }
}
