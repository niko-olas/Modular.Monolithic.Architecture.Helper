// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Application.Core.Orders.Command.CreateOrder;
using MinimalApi.Application.Core.Orders.Query.GetOrderById;
using MinimalApi.Infrastructure;
using Modular.Monolithic.Architecture.Helper.Application;
using Modular.Monolithic.Architecture.Helper.Application.Command;
using Modular.Monolithic.Architecture.Helper.Application.Query;
using Modular.Monolithic.Architecture.Helper.Domain.Results;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHelperApplication();

builder.Services.AddDbContext<MinimalApiDbContext>(options =>
{
    options.UseInMemoryDatabase("MinimalApiDb");
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("/orders", async (
    [FromServices] ICommandHandler<CreateOrderCommand, Result<Guid>> handler,
    [FromBody] IEnumerable<ItemToAdd> items,
    CancellationToken cancellationToken) =>
{
    var result = await handler.Handle(new CreateOrderCommand(items), cancellationToken);

    return Results.Ok(result.Value);

});


app.MapGet("/orders/{id}", async (
    [FromServices] IQueryHandler<GetOrderByIdQuery, Result<OrderDto>> handler,
    Guid id,
    CancellationToken cancellationToken) =>
{
    var result = await handler.Handle(new GetOrderByIdQuery(id), cancellationToken);

    return Results.Ok(result.Value);

});
app.Run();

