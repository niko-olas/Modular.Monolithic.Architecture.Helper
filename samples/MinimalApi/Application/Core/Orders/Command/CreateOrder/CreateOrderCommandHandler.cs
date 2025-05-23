// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MinimalApi.Domain.Orders;
using MinimalApi.Infrastructure;
using Modular.Monolithic.Architecture.Helper.Application.Command;
using Modular.Monolithic.Architecture.Helper.Domain.Results;

namespace MinimalApi.Application.Core.Orders.Command.CreateOrder
{
    public class CreateOrderCommandHandler(MinimalApiDbContext context) : ICommandHandler<CreateOrderCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = Order.Create();

            foreach (ItemToAdd item in command.Items)
            {
                var orderItem = OrderItem.Create(item.ItemId, item.Description, item.Price, order.Id);

                order.AddOrderItem(orderItem);
            }

            context.Add(order);

            await context.SaveChangesAsync();

            return Result.Success(order.Id);
        }
    }


}
