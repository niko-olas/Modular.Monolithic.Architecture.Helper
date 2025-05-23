// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Modular.Monolithic.Architecture.Helper.Application.Query;

public interface IQueryHandler<in TQuery, TResponse>
     where TQuery : IQuery<TResponse>
{
    Task<TResponse> Handle(TQuery command, CancellationToken cancellationToken = default);
}
