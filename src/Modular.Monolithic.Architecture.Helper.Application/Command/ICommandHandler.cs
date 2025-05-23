// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Modular.Monolithic.Architecture.Helper.Application.Command;

/// <summary>
/// Defines a handler for a request with a void response.
/// </summary>
/// <typeparam name="TRequest">The type of request being handled</typeparam>
public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    Task Handle(TCommand request, CancellationToken cancellationToken);
}

/// <summary>
/// Defines a handler for a request
/// </summary>
/// <typeparam name="TRequest">The type of request being handled</typeparam>
/// <typeparam name="TResponse">The type of response from the handler</typeparam>
public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
}

