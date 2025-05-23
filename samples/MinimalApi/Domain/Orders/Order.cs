// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Immutable;
using Modular.Monolithic.Architecture.Helper.Domain.Abstractions;
using Modular.Monolithic.Architecture.Helper.Domain.Core;

namespace MinimalApi.Domain.Orders
{
    public class Order : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
    {
        public DateTime CreatedOn { get; private set; }

        public DateTime? ModifiedOn { get; private set; }

        public DateTime? DeletedOn { get; private set; }

        public bool Deleted { get; private set; }

        private ICollection<OrderItem> _orderItems { get; }
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.ToImmutableList();

        private Order(DateTime createdOn, DateTime? modifiedOn = null, DateTime? deletedOn = null, bool deleted = false) : base(Guid.CreateVersion7())
        {
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
            DeletedOn = deletedOn;
            Deleted = deleted;
            _orderItems = [];
        }

        public static Order Create()
        {
            return new Order(DateTime.UtcNow);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
        }
    }
}
