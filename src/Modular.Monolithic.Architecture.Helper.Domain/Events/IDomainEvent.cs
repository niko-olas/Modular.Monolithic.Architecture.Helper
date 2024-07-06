using MediatR;

namespace Modular.Monolithic.Architecture.Helper.Domain.Events;

/// <summary>
/// Represents the interface for an event that is raised within the domain.
/// </summary>
public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOn { get; }
}
