// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using MinimalApi.Infrastructure;
using Modular.Monolithic.Architecture.Helper.Application.Query;
using Modular.Monolithic.Architecture.Helper.Domain.Errors;
using Modular.Monolithic.Architecture.Helper.Domain.Results;

namespace MinimalApi.Application.Core.Orders.Query.GetOrderById
{
    public class GetOrderByIdQueryHandler(MinimalApiDbContext context) : IQueryHandler<GetOrderByIdQuery, Result<OrderDto>>
    {
        public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery command, CancellationToken cancellationToken = default)
        {
            var result = await context.Orders
                .Select(x => new OrderDto()
                {
                    Id = x.Id,
                    Items = x.OrderItems.Select(x => new ItemDto() { ItemId = x.ItemId, Price = x.Price }).ToList()
                })
                .FirstOrDefaultAsync(x => x.Id == command.orderId, cancellationToken);

            if (result is null)
            {
                return Result.Failure<OrderDto>(DomainErrors.General.ItemNotFound());
            }

            return result;
        }
    }
}
