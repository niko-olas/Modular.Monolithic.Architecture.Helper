using Modular.Monolithic.Architecture.Helper.Domain.Abstractions;
using Modular.Monolithic.Architecture.Helper.Domain.BusinessRules;
using Modular.Monolithic.Architecture.Helper.Domain.Events;
using Modular.Monolithic.Architecture.Helper.Domain.Exceptions;

namespace Modular.Monolithic.Architecture.Helper.Domain.Core;

/// <summary>
/// Represents the base class that all entities derive from.
/// </summary>
public abstract class Entity : TypedIdValueBase
{

    private List<IDomainEvent> _domainEvents;

    /// <summary>
    /// Domain events occurred.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    protected Entity(Guid id) : base(id)
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventItem"></param>
    public void AddDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents ??= [];
        _domainEvents.Add(eventItem);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventItem"></param>
    public void RemoveDomainEvent(IDomainEvent eventItem) => _domainEvents?.Remove(eventItem);
    /// <summary>
    /// 
    /// </summary>
    public void ClearDomainEvents() => _domainEvents?.Clear();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rule"></param>
    /// <exception cref="BusinessRuleValidationException"></exception>
    protected void CheckRule(IBusinessRule rule)
    {
        if (rule.IsFail())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}
