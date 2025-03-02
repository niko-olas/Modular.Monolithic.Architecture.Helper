﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Modular.Monolithic.Architecture.Helper.Domain.Errors;

namespace Modular.Monolithic.Architecture.Helper.Domain.Exceptions;

/// <summary>
/// Represents an exception that occurred in the domain.
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Gets the error.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class.
    /// </summary>
    /// <param name="error">The error containing the information about what happened.</param>
    public DomainException(Error error) : base(error?.Message ?? Error.None.Message) => Error = error ?? Error.None;

    public DomainException() => Error = Error.None;

    public DomainException(string message) : base(message) => Error = new Error(message, message);

    public DomainException(string message, Exception innerException) : base(message, innerException) => Error = new Error(message, message);

}
