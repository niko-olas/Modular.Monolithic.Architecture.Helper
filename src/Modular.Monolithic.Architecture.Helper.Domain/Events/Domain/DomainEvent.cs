// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Modular.Monolithic.Architecture.Helper.Domain.Events.Domain
{
    public abstract record DomainEvent(Guid Id) : IDomainEvent
    {
        public DateTime OccurredOn => DateTime.UtcNow;
    }
}
