// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.DependencyInjection;
using Modular.Monolithic.Architecture.Helper.Application.Command;
using Modular.Monolithic.Architecture.Helper.Application.Query;

namespace Modular.Monolithic.Architecture.Helper.Application;

public static class DipendencyInjection
{
    public static IServiceCollection AddHelperApplication(this IServiceCollection service)
    {
        service.Scan(scan => scan
        .FromApplicationDependencies()
        .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
        .AsImplementedInterfaces().WithScopedLifetime()
        .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
        .AsImplementedInterfaces().WithScopedLifetime()
        .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)), publicOnly: false)
        .AsImplementedInterfaces().WithScopedLifetime());


        return service;
    }
}
