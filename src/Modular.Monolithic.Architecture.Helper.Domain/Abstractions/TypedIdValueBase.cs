// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Modular.Monolithic.Architecture.Helper.Domain.Abstractions;

/// <summary>
/// Represents the id value entities.
/// </summary>
public abstract class TypedIdValueBase : IEquatable<TypedIdValueBase>
{
    /// <summary>
    /// Gets or sets the entity identifier.
    /// </summary>
    public Guid Id { get; private set; }

    protected TypedIdValueBase(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidOperationException("Id value cannot be empty!");
        }

        Id = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(TypedIdValueBase left, TypedIdValueBase right) => Object.Equals(left, null) ? Object.Equals(right, null) : left.Equals(right);

    public static bool operator !=(TypedIdValueBase left, TypedIdValueBase right) => !(left == right);

    /// <inheritdoc />
    public bool IsTransient() => Id == default;

    /// <inheritdoc />
    public override bool Equals(object obj) => obj is not null && obj is TypedIdValueBase other && Equals(other);
    // <inheritdoc />
    public bool Equals(TypedIdValueBase other) => Id == other?.Id;
    /// <inheritdoc />
    public override int GetHashCode() => Id.GetHashCode();
}
