// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Modular.Monolithic.Architecture.Helper.Domain.Core;

namespace MinimalApi.Domain.Orders
{
    public class OrderItem : Entity
    {
        public string Description { get; private set; }

        public string ItemId { get; private set; }

        public decimal Price { get; private set; }

        public Guid OrderId { get; private set; }

        private OrderItem(string itemId, string description, decimal price, Guid orderId) : base(Guid.CreateVersion7())
        {
            Description = description;
            ItemId = itemId;
            Price = price;
            OrderId = orderId;
        }

        public static OrderItem Create(string itemId, string description, decimal price, Guid orderId)
        {
            return new OrderItem(itemId, description, price, orderId);
        }
    }
}
