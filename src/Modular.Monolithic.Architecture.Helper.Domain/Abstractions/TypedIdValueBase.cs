namespace Modular.Monolithic.Architecture.Helper.Domain.Abstractions;

/// <summary>
/// Represents the id value entities.
/// </summary>
public abstract class TypedIdValueBase : IEquatable<TypedIdValueBase>
{
    /// <summary>
    /// Gets or sets the entity identifier.
    /// </summary>
    public Guid Value { get; private set; }

    protected TypedIdValueBase(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidOperationException("Id value cannot be empty!");
        }

        Value = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(TypedIdValueBase left, TypedIdValueBase right)
    {
        if (Object.Equals(left, null))
        {
            return Object.Equals(right, null);
        }
        else
        {
            return left.Equals(right);
        }
    }

    public static bool operator !=(TypedIdValueBase left, TypedIdValueBase right) => !(left == right);

    /// <inheritdoc />
    public bool IsTransient() => Value == default;

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        if (obj is null)
        {
            return false;
        }

        return obj is TypedIdValueBase other && Equals(other);
    }
    // <inheritdoc />
    public bool Equals(TypedIdValueBase other) => Value == other?.Value;
    /// <inheritdoc />
    public override int GetHashCode() => Value.GetHashCode();
}
