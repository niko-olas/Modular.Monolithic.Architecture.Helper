
namespace Modular.Monolithic.Architecture.Helper.Domain.Core;

/// <summary>
/// Represents the base class that rappresent AggregateRoot.
/// </summary>
public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Guid id) : base(id)
    {
    }
}
