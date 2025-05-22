// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Modular.Monolithic.Architecture.Helper.Domain.Events;

public interface IEvent
{
    Guid Id { get; }

    DateTime OccurredOn { get; }
}
