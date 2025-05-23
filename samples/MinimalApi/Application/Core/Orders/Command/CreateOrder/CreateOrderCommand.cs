// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Modular.Monolithic.Architecture.Helper.Application.Command;
using Modular.Monolithic.Architecture.Helper.Domain.Results;

namespace MinimalApi.Application.Core.Orders.Command.CreateOrder
{
    public sealed record class CreateOrderCommand(IEnumerable<ItemToAdd> Items) : ICommand<Result<Guid>>;

    public class ItemToAdd
    {
        public string ItemId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ItemToAdd(string itemId, string description, decimal price)
        {
            ItemId = itemId;
            Description = description;
            Price = price;
        }
    }

}
