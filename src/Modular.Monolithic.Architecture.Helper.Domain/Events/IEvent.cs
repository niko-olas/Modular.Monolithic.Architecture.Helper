using MediatR;

namespace Modular.Monolithic.Architecture.Helper.Domain.Events;

public interface IEvent : INotification
{
    public Guid Id { get; }

    public DateTime OccurredOn { get; }
}
