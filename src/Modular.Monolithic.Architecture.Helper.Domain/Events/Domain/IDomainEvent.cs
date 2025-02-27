// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MediatR;

namespace Modular.Monolithic.Architecture.Helper.Domain.Events.Domain;

public interface IDomainEvent : IEvent, INotification
{
}
