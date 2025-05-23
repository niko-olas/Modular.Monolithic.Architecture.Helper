// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Modular.Monolithic.Architecture.Helper.Application.Query;
using Modular.Monolithic.Architecture.Helper.Domain.Results;

namespace MinimalApi.Application.Core.Orders.Query.GetOrderById;

public sealed record class GetOrderByIdQuery(Guid orderId) : IQuery<Result<OrderDto>>;

public sealed class OrderDto
{
    public Guid Id { get; set; }

    public IReadOnlyList<ItemDto> Items { get; set; }
}

public sealed class ItemDto
{
    public string ItemId { get; set; }

    public decimal Price { get; set; }
}
