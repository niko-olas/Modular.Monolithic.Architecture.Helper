using System;
using System.Collections.Generic;
using System.Text;

namespace Modular.Monolithic.Architecture.Helper.Domain.Events
{
    /// <summary>
    /// Represents the interface for an event that is raised within the domain.
    /// </summary>
    public interface IDomainEvent
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}
