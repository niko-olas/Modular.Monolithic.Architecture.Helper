using System;
using System.Collections.Generic;
using Modular.Monolithic.Architecture.Helper.Domain.BusinessRules;
using Modular.Monolithic.Architecture.Helper.Domain.Events;
using Modular.Monolithic.Architecture.Helper.Domain.Exceptions;

namespace Modular.Monolithic.Architecture.Helper.Domain.Core
{
    /// <summary>
    /// Represents the base class that all entities derive from.
    /// </summary>
    public abstract class Entity : IEquatable<Entity>
    {

        private List<IDomainEvent> _domainEvents;

        /// <summary>
        /// Domain events occurred.
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        protected Entity(Guid id)
            : this()
        {
            Id = id;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <remarks>
        /// Required by EF Core.
        /// </remarks>
        protected Entity()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventItem"></param>
        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventItem"></param>
        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        public bool IsTransient()
        {
            return this.Id == default;
        }
        /// <inheritdoc />
        public bool Equals(Entity other)
        {
            if (other is null)
            {
                return false;
            }

            return ReferenceEquals(this, other) || Id == other.Id;
        }
        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }
        /// <inheritdoc />
        public override int GetHashCode() => this.Id.GetHashCode() ^ 31;
    }
}
