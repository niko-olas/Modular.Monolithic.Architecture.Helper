using System;
using System.Collections.Generic;
using System.Text;

namespace Modular.Monolithic.Architecture.Helper.Domain.Events
{
    public class DomainEvent : IDomainEvent
    {
        public Guid Id { get; }
        public DateTime OccurredOn { get; }

        public DomainEvent()
        {
            this.Id = Guid.NewGuid();
            this.OccurredOn = DateTime.UtcNow;
        }
    }
}
